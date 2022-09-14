using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countPassedCars = 0;

            Queue<string> queue = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (queue.Count > 0)
                        {
                            countPassedCars++;
                            Console.WriteLine(queue.Dequeue() + " passed!");
                        }
                    }
                    continue;
                }
                else if (input == "end")
                {
                    Console.WriteLine($"{countPassedCars} cars passed the crossroads.");
                    break;
                }

                queue.Enqueue(input);
            }
        }
    }
}
