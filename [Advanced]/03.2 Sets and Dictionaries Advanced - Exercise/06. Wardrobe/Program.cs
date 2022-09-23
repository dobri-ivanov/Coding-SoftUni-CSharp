using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string colour = tokens[0];
                string[] products = tokens[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!clothes.ContainsKey(colour))
                {
                    clothes[colour] = new Dictionary<string, int>();
                }
                foreach (var product in products)
                {
                    if (!clothes[colour].ContainsKey(product))
                    {
                        clothes[colour][product] = 0;
                    }
                    clothes[colour][product]++;
                }
            }
            string[] resultInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string resultColour = resultInput[0];
            string resultProduct = resultInput[1];

            foreach (var cloth in clothes)
            {
                Console.WriteLine($"{cloth.Key} clothes:");
                if (cloth.Key == resultColour)
                {
                    foreach (var colour in clothes[cloth.Key])
                    {
                        if (colour.Key == resultProduct)
                        {
                            Console.WriteLine($"* {colour.Key} - {colour.Value} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {colour.Key} - {colour.Value}");
                        }
                    }
                }
                else
                {
                    foreach (var colour in clothes[cloth.Key])
                    {
                        Console.WriteLine($"* {colour.Key} - {colour.Value}");
                    }
                }
            }
        }
    }
}