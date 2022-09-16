using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            Queue<string> songQueue = new Queue<string>(songs);

            string[] tokens = Console.ReadLine().Split();
            string command = tokens[0];

            while (true)
            {
                if (command == "Play")
                {
                    songQueue.Dequeue();
                    if (songQueue.Count == 0)
                    {
                        Console.WriteLine("No more songs!");
                        return;
                    }
                }
                else if (command == "Add")
                {
                    string song = String.Join(" ", tokens.Skip(1));
                    if (songQueue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songQueue.Enqueue(song);
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(String.Join(", ", songQueue));
                }
                tokens = Console.ReadLine().Split();
                command = tokens[0];
            }
        }
    }
}