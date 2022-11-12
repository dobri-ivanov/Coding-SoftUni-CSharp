using System;
using System.Collections.Generic;
using System.Linq;

namespace _03Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                if (type == "Druid")
                {
                    BaseHero druid = new Druid(name);
                    heroes.Add(druid);
                }
                else if (type == "Rogue")
                {
                    BaseHero rogue = new Rogue(name);
                    heroes.Add(rogue);
                }
                else if (type == "Paladin")
                {
                    BaseHero paladin = new Paladin(name);
                    heroes.Add(paladin);
                }
                else if (type == "Warrior")
                {
                    BaseHero warrior = new Warrior(name);
                    heroes.Add(warrior);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            int power = int.Parse(Console.ReadLine());
            

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int heroesPower = heroes.Select(x => x.Power).Sum();
            Console.WriteLine(heroesPower >= power ? "Victory!" : "Defeat...");
        }
    }
}
