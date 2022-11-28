using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        const int BELT_WEIGHT = 10000;
        const int BELT_PRICE = 80;

        public Kettlebell() : base(BELT_WEIGHT, BELT_PRICE)
        {
        }
    }
}
