using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace NavalVessels.Models.Vessels
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThinkness;
        private double mainWeaponCaliber;
        private double speed;
        private List<string> targets;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            targets = new List<string>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                name = value;
            }
        }

        public ICaptain Captain
        {
            get { return captain; }
            set
            {
                if (value == null) throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                captain = value;
            }
        }
        public double ArmorThickness
        {
            get { return armorThinkness; }
            set
            {
                if (armorThinkness < 0)
                {
                    armorThinkness = 0;
                }
                else
                {
                    armorThinkness = value;
                }
            }
        }


        public double MainWeaponCaliber
        {
            get { return mainWeaponCaliber; }
            protected set { mainWeaponCaliber = value; }
        }

        public double Speed
        {
            get { return speed; }
            protected set { speed = value; }
        }

        public ICollection<string> Targets => targets.AsReadOnly();

        public void Attack(IVessel target)
        {
            if (target == null) throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            target.ArmorThickness -= MainWeaponCaliber;
            targets.Add(target.Name);
        }

        public virtual void RepairVessel()
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string targetsString = Targets.Any() ? string.Join(", ", targets) : "None";

            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");
            sb.Append($" *Targets: " + targetsString);
            return sb.ToString().TrimEnd();
        }

    }
}
