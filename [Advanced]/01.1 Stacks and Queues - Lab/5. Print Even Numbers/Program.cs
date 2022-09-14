using System;
using System.Linq;
using System.Collections.Generic;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();
            Queue<int> queue2 = new Queue<int>();

            for (int i = 0; i < array.Length; i++)
            {
                queue.Enqueue(array[i]);
            }

            while (queue.Count > 0)
            {
                int number = queue.Dequeue();
                if (number % 2 == 0) // even
                {
                    queue2.Enqueue(number);
                }
            }
            Console.WriteLine(String.Join(", ", queue2));

        }
    }
}
