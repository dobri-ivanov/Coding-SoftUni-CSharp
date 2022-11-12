using System;
using System.Collections.Generic;
using System.Text;

namespace _03Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name)
        {
            this.Name = name;
            this.Power = 0;
        }
        public string Name { get; set; }
        public int Power { get; set; }
        public virtual string CastAbility()
        {
            this.Power += 80;
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
