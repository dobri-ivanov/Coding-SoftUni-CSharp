using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        private List<IHero> knights;
        private List<IHero> barbarians;
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = new List<IHero>();
            List<IHero> barbarians = new List<IHero>();
            foreach (IHero hero in players)
            {
                if (hero.GetType() == typeof(Knight))
                    knights.Add(hero);
                else barbarians.Add(hero);
            }
            bool itIsKnightsTurn = true;
            while (knights.Any(k => k.IsAlive) && barbarians.Any(b => b.IsAlive))
            {
                if (itIsKnightsTurn)
                {
                    itIsKnightsTurn=false;
                    PlayOutRound(knights, barbarians);
                }
                else
                {
                    itIsKnightsTurn = true;
                    PlayOutRound(barbarians, knights);
                }
            }
            if (knights.Any(k => k.IsAlive))
                return $"The knights took {knights.Where(k => !k.IsAlive).Count()} casualties but won the battle.";
            else
                return $"The barbarians took {barbarians.Where(b => !b.IsAlive).Count()} casualties but won the battle.";
        }

        private void PlayOutRound(List<IHero> attackers, List<IHero> defenders)
        {
            foreach (IHero attacker in attackers)
                for (int i = 0; i < defenders.Count; i++)
                    if(attacker.IsAlive && defenders[i].IsAlive)
                    defenders[i].TakeDamage(attacker.Weapon.DoDamage());
        }
    }
}

