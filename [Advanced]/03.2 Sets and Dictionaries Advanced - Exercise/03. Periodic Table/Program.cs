using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> chemicals = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                chemicals.UnionWith(input);
            }

            Console.WriteLine(String.Join(" ", chemicals));
        }
    }
}