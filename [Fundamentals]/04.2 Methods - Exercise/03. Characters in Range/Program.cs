using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstChar = (int)char.Parse(Console.ReadLine());
            int secondChar = (int)char.Parse(Console.ReadLine());
            PrintChars(firstChar, secondChar);

        }

        private static void PrintChars(int firstChar, int secondChar)
        {
            int startChar = Math.Min(firstChar, secondChar);
            int endChar = Math.Max(firstChar, secondChar);

            for (int i = startChar  + 1; i < endChar; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
