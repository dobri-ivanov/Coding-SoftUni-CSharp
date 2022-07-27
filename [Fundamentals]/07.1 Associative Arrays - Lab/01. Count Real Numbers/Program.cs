using System;
using System.Linq;
using System.Collections.Generic;

namespace _1._Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int, int> Counter = new SortedDictionary<int, int>();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (var number in numbers)
            {
                if (!Counter.ContainsKey(number))
                {
                    Counter.Add(number, 1);
                }
                else
                {
                    Counter[number]++;
                }
            }

            foreach (var number in Counter)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}