using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Vlogger> database = new List<Vlogger>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Statistics")
                {
                    break;
                }
                if (tokens[1] == "joined")
                {
                    string vloger = tokens[0];
                    if (!database.Any(x => x.Name == vloger))
                    {
                        database.Add(new Vlogger(vloger));
                    }
                }
                else if (tokens[1] == "followed")
                {
                    string vlogerName = tokens[0];
                    string followedVlogerName = tokens[2];

                    if (vlogerName == followedVlogerName ||
                        !database.Any(x => x.Name == vlogerName) ||
                        !database.Any(x => x.Name == followedVlogerName))
                    {
                        continue;
                    }

                    Vlogger follwingVloger = database.Single(x => x.Name == vlogerName);
                    follwingVloger.Following.Add(followedVlogerName);

                    Vlogger followedVloger = database.Single(x => x.Name == followedVlogerName);
                    followedVloger.Follwers.Add(vlogerName);
                }
            }

            database = database
                .OrderByDescending(x => x.Follwers.Count)
                .ThenBy(x => x.Following.Count)
                .ToList();

            Console.WriteLine($"The V-Logger has a total of {database.Count} vloggers in its logs.");
            int count = 1;

            foreach (var vlogger in database)
            {
                Console.WriteLine($"{count}. {vlogger.Name} : {vlogger.Follwers.Count} followers, {vlogger.Following.Count} following");
                if (count == 1)
                {
                    foreach (var follower in vlogger.Follwers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                count++;
            }
        }
    }

    internal class Vlogger
    {
        public string Name { get; set; }
        public SortedSet<string> Follwers { get; set; }
        public HashSet<string> Following { get; set; }

        public Vlogger(string name)
        {
            Name = name;
            Follwers = new SortedSet<string>();
            Following = new HashSet<string>();
        }
    }
}