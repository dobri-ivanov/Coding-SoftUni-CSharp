using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbersCounter = new Dictionary<double, int>();

            double[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            foreach (var number in input)
            {
                if (!numbersCounter.ContainsKey(number))
                {
                    numbersCounter[number] = 0;
                }
                numbersCounter[number]++;
            }

            foreach (var number in numbersCounter)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
