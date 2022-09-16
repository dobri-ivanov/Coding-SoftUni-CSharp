using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(orders);
            int biggestOrder = queue.Max();
            Console.WriteLine(biggestOrder);

            int sumOfOrders = queue.Sum();
            if (sumOfOrders <= food)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                while (food > queue.Peek())
                {
                    food -= queue.Dequeue();
                }
                Console.WriteLine("Orders left: " + String.Join(" ", queue));
            }
        }
    }
}