using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            Console.WriteLine(VowelsCount(input));
        }

        private static int VowelsCount(string input)
        {
            int counter = 0;
            foreach (char symbol in input)
            {
                if ("aeiou".Contains(symbol))
                {
                    counter++;
                }
            }
            return counter;
            
        }
    }
}
