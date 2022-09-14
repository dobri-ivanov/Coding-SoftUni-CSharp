using System;
using System.Linq;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(array);
            int turn = 0;
            while (queue.Count > 1)
            {
                string kid = queue.Dequeue();
                turn++;

                if (turn == n)
                {
                    turn = 0;
                    Console.WriteLine("Removed " + kid);
                    continue;
                }

                queue.Enqueue(kid);    
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
