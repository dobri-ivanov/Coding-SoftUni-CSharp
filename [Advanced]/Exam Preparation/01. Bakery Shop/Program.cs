
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bakery_Shop
{
    public class Program
    {
        static void Main(string[] args)

        {
            Dictionary<string, int> sweetsCollection = new Dictionary<string, int>();
            Dictionary<string, int> sweetsProportion = new Dictionary<string, int>();
            sweetsProportion.Add("Croissant", 50);
            sweetsProportion.Add("Muffin", 40);
            sweetsProportion.Add("Baguette", 30);
            sweetsProportion.Add("Bagel", 20);


            Queue<double> water = new Queue<double>();
            Stack<double> flour = new Stack<double>();

            double[] waterInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            double[] flourInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            for (int i = 0; i < waterInput.Length; i++)
            {
                water.Enqueue(waterInput[i]);
            }
            for (int j = 0; j < flourInput.Length; j++)
            {
                flour.Push(flourInput[j]);
            }

            while (true)
            {
                if (water.Count == 0 || flour.Count == 0)
                {
                    break;
                }
                double currentWater = water.Peek();
                double currentFlour = flour.Peek();
                double currentWaterPercentage = (currentWater * 100) / (currentWater + currentFlour);

                bool match = false;
                foreach (var sweeets in sweetsProportion)
                {
                    if (currentWaterPercentage == sweeets.Value)
                    {
                        if (!sweetsCollection.ContainsKey(sweeets.Key))
                        {
                            sweetsCollection.Add(sweeets.Key, 0);
                        }
                        sweetsCollection[sweeets.Key]++;
                        if (water.Any())
                        {
                            water.Dequeue();
                        }
                        if (flour.Any())
                        {
                            flour.Pop();
                        }
                        match = true;
                        break;
                    }
                }

                if (match == false)
                {
                    if (water.Any())
                    {
                        water.Dequeue();
                    }
                    if (flour.Any())
                    {
                        double newFlour = flour.Pop() - currentWater;
                        flour.Push(newFlour);
                    }

                    if (!sweetsCollection.ContainsKey("Croissant"))
                    {
                        sweetsCollection.Add("Croissant", 0);
                    }
                    sweetsCollection["Croissant"]++;
                }
            }

            sweetsCollection = sweetsCollection
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var sweet in sweetsCollection)
            {
                Console.WriteLine($"{sweet.Key}: {sweet.Value}");
            }

            Console.Write("Water left: ");
            if (water.Any())
            {
                Console.WriteLine(String.Join(", ", water));
            }
            else
            {
                Console.WriteLine("None");
            }

            Console.Write("Flour left: ");
            if (flour.Any())
            {
                Console.WriteLine(String.Join(", ", flour));
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }
}
