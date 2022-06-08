using System;

namespace _05._Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int startDigit = int.Parse(Console.ReadLine());
            int endDigit = int.Parse(Console.ReadLine());

            for (int i = startDigit; i <= endDigit; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
