using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
           
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            Predicate<int> isDevideble = num => num % n == 0;


            input = input.Reverse().ToArray();

            foreach (var number in input)
            {
                if (!isDevideble(number))
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
