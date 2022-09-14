using System;
using System.Linq;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Paid")
                {
                    while (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else if (input == "End")
                {
                    Console.WriteLine($"{queue.Count} people remaining.");
                    break;
                }
                else
                {
                    queue.Enqueue(input);
                }

            }
        }
    }
}
