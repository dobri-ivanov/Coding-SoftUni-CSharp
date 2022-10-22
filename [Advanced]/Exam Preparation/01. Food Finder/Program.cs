using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _01._Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> wordsFound = new HashSet<string>();
            List<string> words = new List<string>();
            words.Add("pear");
            words.Add("flour");
            words.Add("pork");
            words.Add("olive");

            Queue<char> vowels = new Queue<char>();
            Stack<char> consonants = new Stack<char>();
            char[] vowelsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            char[] consonantsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

            for (int i = 0; i < vowelsInput.Length; i++)
            {
                vowels.Enqueue(vowelsInput[i]);
            }
            for (int i = 0; i < consonantsInput.Length; i++)
            {
                consonants.Push(consonantsInput[i]);
            }

            while (consonants.Any())
            {
                char currentVowel = vowels.Dequeue();
                vowels.Enqueue(currentVowel);
                char currentConsonants = consonants.Pop();

                for (int i = 0; i < words.Count; i++)
                {
                    if (!words[i].Contains(currentVowel.ToString()) || words[i].Contains(currentConsonants.ToString()))
                    {
                        words.Remove(words[i]);
                    }
                }
            }
            Console.WriteLine($"Words found: {words.Count}");
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
