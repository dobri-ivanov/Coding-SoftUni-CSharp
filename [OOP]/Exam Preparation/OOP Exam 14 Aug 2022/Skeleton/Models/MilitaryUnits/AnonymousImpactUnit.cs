using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public class AnonymousImpactUnit : MilitaryUnit
    {
        const double COST = 2.5;
        public AnonymousImpactUnit() : base(COST)
        {
        }
    }
}
