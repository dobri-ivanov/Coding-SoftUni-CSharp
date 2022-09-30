using System;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = words =>
            {
                foreach (var word in words)
                {
                    Console.WriteLine($"Sir {word}");
                }
            };

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            print(input);
        }
    }
}
