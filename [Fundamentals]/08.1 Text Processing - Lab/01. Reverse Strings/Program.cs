using System;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            while (word != "end")
            {
                string revercedString = string.Empty;

                for (int i = word.Length - 1; i >= 0; i--)
                {
                    revercedString += word[i];
                }

                Console.WriteLine($"{word} = {revercedString}");
                word = Console.ReadLine();
            }
            
        }
    }
}
