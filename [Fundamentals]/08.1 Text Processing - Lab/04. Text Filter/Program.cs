using System;

namespace _04._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            foreach (var word in bannedWords)
            {
                string replacement = string.Empty;

                foreach (var symbol in word)
                {
                    replacement += '*';
                }

                text = text.Replace(word, replacement);
            }
            Console.WriteLine(text);
        }
    }
}
