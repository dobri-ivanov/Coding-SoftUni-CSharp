using NavalVessels.Core.Contracts;
using NavalVessels.Models.Captains;
using NavalVessels.Models.Contracts;
using NavalVessels.Models.Vessels;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private IRepository<IVessel> vessels;
        private List<ICaptain> captains;
        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }
        public string HireCaptain(string fullName)
        {
            if (captains.Any(x => x.FullName == fullName)) return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            ICaptain captain = new Captain(fullName);
            captains.Add(captain);
            return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }
        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vessels.Models.Any(x => x.Name == name)) return String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            IVessel vessel;
            if (vesselType == nameof(Submarine))
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == nameof(Battleship))
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                return OutputMessages.InvalidVesselType;
            }
            vessels.Add(vessel);
            return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            if (!captains.Any(x => x.FullName == selectedCaptainName)) return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            ICaptain captain = captains.Find(x => x.FullName == selectedCaptainName);

            if (!vessels.Models.Any(x => x.Name == selectedVesselName)) return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            IVessel vessel = vessels.FindByName(selectedVesselName);

            if (vessel.Captain != null) return String.Format(OutputMessages.VesselOccupied, selectedVesselName);

            captain.AddVessel(vessel);
            vessel.Captain = captain;
            return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }
        public string CaptainReport(string captainFullName)
        {
            if (captains.Any(x => x.FullName == captainFullName))
            {
                ICaptain captain = captains.Find(x => x.FullName == captainFullName);
                return captain.Report();
            }
            return null;
        }
        public string VesselReport(string vesselName)
        {
            if (vessels.FindByName(vesselName) != null)
            {
                IVessel vessel = vessels.FindByName(vesselName);
                return vessel.ToString();
            }
            return null;
        }
        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel;
            if (vessels.FindByName(vesselName) != null)
            {
                vessel = vessels.FindByName(vesselName);
                if (vessel.GetType().Name == nameof(Battleship))
                {
                    (vessel as Battleship).ToggleSonarMode();
                    return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
                }
                else
                {
                    (vessel as Submarine).ToggleSubmergeMode();
                    return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
                }
            }
            else
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }
        }
        public string ServiceVessel(string vesselName)
        {
            if (vessels.FindByName(vesselName) == null) return String.Format(OutputMessages.VesselNotFound, vesselName);
            IVessel vessel = vessels.FindByName(vesselName);
            vessel.RepairVessel();
            return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }
        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            if (vessels.FindByName(attackingVesselName) == null) return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            if (vessels.FindByName(defendingVesselName) == null) return String.Format(OutputMessages.VesselNotFound, defendingVesselName);

            IVessel attackingVessel = vessels.FindByName(attackingVesselName);
            IVessel defendingVessel = vessels.FindByName(defendingVesselName);

            if (attackingVessel.ArmorThickness == 0) return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            if (defendingVessel.ArmorThickness == 0) return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);

            attackingVessel.Attack(defendingVessel);
            attackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();

            return String.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defendingVessel.ArmorThickness);
        }











    }
}
