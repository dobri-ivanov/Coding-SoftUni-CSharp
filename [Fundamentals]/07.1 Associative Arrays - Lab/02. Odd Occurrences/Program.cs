using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> occurenceByWords = new Dictionary<string, int>();
            string[] words = Console.ReadLine().Split();

            foreach (var word in words)
            {
                string newWord = word.ToLower();
                if (occurenceByWords.ContainsKey(newWord))
                {
                    occurenceByWords[newWord]++;
                }
                else
                {
                    occurenceByWords.Add(newWord, 1);
                }
            }

            foreach (var element in occurenceByWords)
            {
                if (element.Value % 2 != 0)
                {
                    Console.Write(element.Key + " ");
                }
            }
        }
    }
}
