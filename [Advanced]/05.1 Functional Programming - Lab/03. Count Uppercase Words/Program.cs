using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                char firstLetter = word[0];
                if (char.IsUpper(firstLetter))
                {
                    Console.WriteLine(word);
                }
            }

        }
    }
}
