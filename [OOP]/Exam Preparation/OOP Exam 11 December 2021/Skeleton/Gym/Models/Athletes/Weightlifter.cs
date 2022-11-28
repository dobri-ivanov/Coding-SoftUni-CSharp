using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        const int CURRENT_ATHLETE_STAMINA = 50;
        public Weightlifter(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, CURRENT_ATHLETE_STAMINA)
        {
        }

        public override void Exercise()
        {
            this.Stamina += 10;

        }
    }
}
