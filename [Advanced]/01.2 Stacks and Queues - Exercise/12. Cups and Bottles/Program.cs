using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottlesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(cupsInput);
            Stack<int> bottles = new Stack<int>(bottlesInput);
            int currentCupValue = 0;
            int wastedLitters = 0;

            while (cups.Count > 0)
            {
                currentCupValue = cups.Dequeue();
                while (currentCupValue > 0)
                {
                    if (bottles.Count == 0)
                    {
                        Console.WriteLine("Cups: " + String.Join(" ", cups));
                        Console.WriteLine($"Wasted litters of water: {wastedLitters}");
                        return;
                    }
                    int currentBottleValue = bottles.Pop();

                    if (currentBottleValue <= currentCupValue)
                    {
                        currentCupValue -= currentBottleValue;
                    }
                    else
                    {
                        wastedLitters += currentBottleValue - currentCupValue;
                        currentCupValue = 0;
                    }
                    if (bottles.Count == 0)
                    {
                        Console.WriteLine("Cups: " + String.Join(" ", cups));
                        Console.WriteLine($"Wasted litters of water: {wastedLitters}");
                        return;
                    }
                }
            }
            Console.WriteLine($"Bottles: {String.Join(" ", bottles)}");
            Console.WriteLine($"Wasted litters of water: {wastedLitters}");
        }
    }
}
