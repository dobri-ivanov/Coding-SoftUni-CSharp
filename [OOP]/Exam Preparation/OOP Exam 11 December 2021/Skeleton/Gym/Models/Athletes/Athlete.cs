using Gym.Models.Athletes.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int stamina;
        private int numberOfMedals;

        public Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            FullName = fullName;
            Motivation = motivation;
            NumberOfMedals = numberOfMedals;
            Stamina = stamina;
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (String.IsNullOrEmpty(value)) throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                fullName = value;
            }
        }

        public string Motivation
        {
            get { return motivation; }
            private set
            {
                if (String.IsNullOrEmpty(value)) throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                motivation = value;
            }
        }

        public int Stamina
        {
            get => stamina;
            protected set
            {
                if (value > 100)
                {
                    stamina = 100;
                    throw new ArgumentException(ExceptionMessages.InvalidStamina);
                }
                else
                {
                    stamina = value;
                }
            }
        }

        public int NumberOfMedals
        {
            get { return numberOfMedals; }
            private set
            {
                if (value < 0) throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                numberOfMedals = value;
            }
        }

        public abstract void Exercise();

    }
}
