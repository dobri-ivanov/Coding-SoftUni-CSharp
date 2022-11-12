using System;
using System.Collections.Generic;
using System.Text;

namespace _03Raiding
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) : base(name)
        {
        }

        public override string CastAbility()
        {
            this.Power += 80;
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
