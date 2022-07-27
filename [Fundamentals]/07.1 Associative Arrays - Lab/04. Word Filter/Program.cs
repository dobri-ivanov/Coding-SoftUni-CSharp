using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Word_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsByLenght = new Dictionary<string, int>();
            //string[] words = Console.ReadLine().Split();

            string[] words = Console.ReadLine()
                .Split()
                .Where(word => word.Length % 2 == 0)
                .ToArray();

            foreach (var word in words)
            {
                wordsByLenght.Add(word, word.Length);
            }
            foreach (var word in wordsByLenght)
            {
                if (word.Value % 2 == 0)
                {
                    Console.WriteLine(word.Key);
                }
            }
        }
    }
}
