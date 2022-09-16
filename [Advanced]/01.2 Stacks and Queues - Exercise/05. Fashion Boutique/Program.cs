using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] deliveries = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());
            int backup = capacity;

            Stack<int> stack = new Stack<int>(deliveries);

            int count = 1;
            while (stack.Count > 0)
            {
                if (capacity < stack.Peek() || capacity == 0)
                {
                    count++;
                    capacity = backup;
                }
                capacity -= stack.Pop();
            }
            Console.WriteLine(count);
        }
    }
}