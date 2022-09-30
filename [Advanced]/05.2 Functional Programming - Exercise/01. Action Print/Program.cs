using System;

namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> action = words =>
            {
                Console.WriteLine(String.Join(Environment.NewLine, words));
            };

            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            action(words);
        }
    }
}
