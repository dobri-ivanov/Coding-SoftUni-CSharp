using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> words = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                words.Add(input);
            }

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}