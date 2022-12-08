using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Vessels
{
    public class Battleship : Vessel, IBattleship
    {
        private bool sonarMode;
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 300)
        {
            SonarMode = false;
        }

        public bool SonarMode
        {
            get { return sonarMode; }
            private set { sonarMode = value; }
        }

        public void ToggleSonarMode()
        {
            SonarMode = !SonarMode;
            if (SonarMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }
        public override void RepairVessel()
        {
            ArmorThickness = 300;
        }
        public override string ToString()
        {
            string sonarModeText = SonarMode ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $" *Sonar mode: {sonarModeText}";
        }
    }
}
