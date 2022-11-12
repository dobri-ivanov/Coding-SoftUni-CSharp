using System;
using System.Collections.Generic;
using System.Text;

namespace _03Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
        }
        public override string CastAbility()
        {
            this.Power += 100;
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
