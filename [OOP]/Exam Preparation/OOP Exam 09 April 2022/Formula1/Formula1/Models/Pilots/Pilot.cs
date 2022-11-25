using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models.Pilots
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        private int numbersOfWins;

        public Pilot(string fullName)
        {
            this.fullName = fullName;
            this.CanRace = false;
        }
        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5) throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                fullName = value;
            }
        }
        public bool CanRace { get; private set; }
        

        public IFormulaOneCar Car
        {
            get { return car; }
            private set
            {
                if (value == null) throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarForPilot));
                car = value;
            }
        }

        public int NumberOfWins
        {
            get { return numbersOfWins; }
            private set { numbersOfWins = value; }
        }

        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
        public override string ToString()
        {
            return string.Format($"Pilot {FullName} has {NumberOfWins} wins.");
        }
    }
}
