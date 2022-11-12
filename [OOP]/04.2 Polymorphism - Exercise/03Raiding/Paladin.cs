using System;
using System.Collections.Generic;
using System.Text;

namespace _03Raiding
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) : base(name)
        {
        }
        public override string CastAbility()
        {
            this.Power += 100;
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
