using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continentsInfo = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                if (!continentsInfo.ContainsKey(continent))
                {
                    continentsInfo[continent] = new Dictionary<string, List<string>>();
                }
                if (!continentsInfo[continent].ContainsKey(country))
                {
                    continentsInfo[continent][country] = new List<string>();
                }

                continentsInfo[continent][country].Add(city);
            }

            foreach (var continent in continentsInfo)
            {
                Console.WriteLine(continent.Key + ':');

                foreach (var country in continentsInfo[continent.Key])
                {
                    Console.WriteLine($"  {country.Key} -> {String.Join(", ", continentsInfo[continent.Key][country.Key])}");
                }
            }
        }
    }
}
