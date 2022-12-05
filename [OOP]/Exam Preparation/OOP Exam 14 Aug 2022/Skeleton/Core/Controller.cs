using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Xml.Linq;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private IRepository<IPlanet> planets;
        public Controller()
        {
            planets = new PlanetRepository();
        }
        public string CreatePlanet(string name, double budget)
        {
            if (planets.Models.Any(x => x.Name == name)) return String.Format(OutputMessages.ExistingPlanet, name);
            IPlanet planet = new Planet(name, budget);
            planets.AddItem(planet);
            return String.Format(OutputMessages.NewPlanet, name);
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            if (!planets.Models.Any(x => x.Name == planetName)) throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            IPlanet planet = planets.FindByName(planetName);
            IMilitaryUnit unit;
            if (unitTypeName == nameof(AnonymousImpactUnit))
            {
                unit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            if (planet.Army.Any(x => x.GetType().Name == unitTypeName)) throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            planet.Spend(unit.Cost);
            planet.AddUnit(unit);
            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }
        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (!planets.Models.Any(x => x.Name == planetName)) throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            IPlanet planet = planets.FindByName(planetName);
            IWeapon weapon;
            if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(SpaceMissiles))
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            if (planet.Weapons.Any(x => x.GetType().Name == weaponTypeName)) throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }
        public string SpecializeForces(string planetName)
        {
            if (!planets.Models.Any(x => x.Name == planetName)) throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            IPlanet planet = planets.FindByName(planetName);
            if (!planet.Army.Any()) throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            planet.Spend(1.25);
            planet.TrainArmy();
            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }
        public string SpaceCombat(string planetOne, string planetTwo)
        {
            if (!planets.Models.Any(x => x.Name == planetOne)) return String.Format(OutputMessages.ExistingPlanet, planetOne);
            if (!planets.Models.Any(x => x.Name == planetTwo)) return String.Format(OutputMessages.ExistingPlanet, planetTwo);
            IPlanet planet1 = planets.FindByName(planetOne);
            IPlanet planet2 = planets.FindByName(planetTwo);

            if (planet1.MilitaryPower == planet2.MilitaryPower)
            {
                if ((planet1.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)) && planet2.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon))) ||
                    !planet1.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)) && !planet2.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet2.Spend(planet2.Budget / 2);
                    return OutputMessages.NoWinner;
                }
                else
                {
                    if (planet1.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
                    {
                        planet1.Spend(planet1.Budget / 2);
                        planet1.Profit(planet2.Budget / 2);
                        double amount = CalculateAmount(planet2);
                        planet1.Profit(amount);
                        planets.RemoveItem(planetTwo);
                        return String.Format(OutputMessages.WinnigTheWar, planet1.Name, planet2.Name);
                    }
                    else
                    {
                        planet2.Spend(planet2.Budget / 2);
                        planet2.Profit(planet1.Budget / 2);
                        double amount = CalculateAmount(planet1);
                        planet2.Profit(amount);
                        planets.RemoveItem(planetOne);
                        return String.Format(OutputMessages.WinnigTheWar, planet2.Name, planet1.Name);
                    }
                }
            }
            else
            {
                if (planet1.MilitaryPower > planet2.MilitaryPower)
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet1.Profit(planet2.Budget / 2);
                    double amount = CalculateAmount(planet2);
                    planet1.Profit(amount);
                    planets.RemoveItem(planetTwo);
                    return String.Format(OutputMessages.WinnigTheWar, planet1.Name, planet2.Name);
                }
                else
                {
                    planet2.Spend(planet2.Budget / 2);
                    planet2.Profit(planet1.Budget / 2);
                    double amount = CalculateAmount(planet1);
                    planet2.Profit(amount);
                    planets.RemoveItem(planetOne);
                    return String.Format(OutputMessages.WinnigTheWar, planet2.Name, planet1.Name);
                }
            }
        }
        private double CalculateAmount(IPlanet planet)
        {
            return planet.Army.Sum(x => x.Cost) + planet.Weapons.Sum(x => x.Price);

        }
        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            var orderedPlanets = planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name);
            if (planets.Models.Any())
            {
                foreach (var planet in orderedPlanets)
                {
                    sb.AppendLine(planet.PlanetInfo());
                }
            }
            return sb.ToString().TrimEnd();
        }


    }
}
