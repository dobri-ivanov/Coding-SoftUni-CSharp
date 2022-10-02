using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Predicate<int>> predicates = new List<Predicate<int>>();
            int endNum = int.Parse(Console.ReadLine());
            int[] filtersInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            HashSet<int> filters = new HashSet<int>();
            foreach (var filter in filtersInput)
            {
                filters.Add(filter);
            }

            foreach (var filter in filters)
            {
                predicates.Add(num => num % filter == 0);
            }

            int[] numbers = Enumerable.Range(1, endNum).ToArray();
            foreach (var num in numbers)
            {
                bool isVailid = true;
                foreach (var predicate in predicates)
                {
                    if (!predicate(num))
                    {
                        isVailid = false;
                        break;
                    }
                }
                if (isVailid)
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}
