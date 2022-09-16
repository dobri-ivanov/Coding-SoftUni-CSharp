using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int>petrol = new Queue<int>();
            Queue<int> distance = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                petrol.Enqueue(input[0]);
                distance.Enqueue(input[1]);
            }
            int index = 0;
            while (petrol.Count > 0)
            {
                if (petrol.Dequeue() > distance.Dequeue())
                {
                    Console.WriteLine(index);
                    return;
                }
                index++;
            }
        }
    }
}
