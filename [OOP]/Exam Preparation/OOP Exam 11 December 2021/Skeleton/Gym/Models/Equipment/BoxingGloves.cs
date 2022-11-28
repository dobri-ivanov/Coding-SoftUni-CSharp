using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        const int GLOVES_WEIGHT = 227;
        const int GLOVES_PRICE = 120;

        public BoxingGloves() : base(GLOVES_WEIGHT, GLOVES_PRICE)
        {
        }
    }
}
