using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public class StormTroopers : MilitaryUnit
    {
        const double COST = 2.5;
        public StormTroopers() : base(COST)
        {
        }
    }
}
