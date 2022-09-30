using System;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = num => num % 2 == 0;
            Predicate<int> isOdd = num => num % 2 != 0;

            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            int start = input[0];
            int end = input[1];

            if (command == "even")
            {
                for (int i = start; i <= end; i++)
                {
                    if (isEven(i))
                    {
                        Console.Write(i + " ");
                    }
                }
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    if (isOdd(i))
                    {
                        Console.Write(i + " ");
                    }
                }
            }
        }
    }
}
