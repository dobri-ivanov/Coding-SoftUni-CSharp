using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private List<IMilitaryUnit> units;
        private List<IWeapon> weapons;
        private string name;
        private double budget;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new List<IMilitaryUnit>();
            weapons = new List<IWeapon>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                name = value;
            }
        }

        public double Budget
        {
            get { return budget; }
            private set
            {
                if (value < 0) throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                budget = value;
            }
        }

        public double MilitaryPower => CalculateTotalAmount();

        private double CalculateTotalAmount()
        {
            double totalPower = units.Sum(x => x.EnduranceLevel) + weapons.Sum(x => x.DestructionLevel);
            if (units.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                totalPower += totalPower * 0.30;
            }
            if (weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
            {
                totalPower += totalPower * 0.45;
            }
            return Math.Round(totalPower, 3);

        }

        public IReadOnlyCollection<IMilitaryUnit> Army => units.AsReadOnly();

        public IReadOnlyCollection<IWeapon> Weapons => weapons.AsReadOnly();

        public void AddUnit(IMilitaryUnit unit)
        {
            units.Add(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            string currentUnits;
            string currentWeapons;

            if (units.Any())
            {
                currentUnits = String.Join(", ", units.Select(u => u.GetType().Name));
            }
            else
            {
                currentUnits = "No units";
            }
            if (weapons.Any())
            {
                currentWeapons = String.Join(", ", weapons.Select(x => x.GetType().Name));
            }
            else
            {
                currentWeapons = "No weapons";
            }
            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.AppendLine($"--Forces: {currentUnits}");
            sb.AppendLine($"--Combat equipment: {currentWeapons}");
            sb.AppendLine($"--ilitary Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            if (amount > Budget) throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            Budget -= amount;
        }

        public void TrainArmy()
        {
            units.ForEach(x => x.IncreaseEndurance());
        }
    }
}
