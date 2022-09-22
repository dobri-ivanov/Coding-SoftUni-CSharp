using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[] sorted = input.OrderByDescending(x => x).Take(3).ToArray();
            Console.WriteLine(String.Join(" ", sorted));
        }
    }
}
