using System;

namespace _01._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');

            Random r = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int randomIndex = r.Next(0, words.Length);

                string currentWord = words[i];

                words[i] = words[randomIndex];
                words[randomIndex] = currentWord;
            }

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
