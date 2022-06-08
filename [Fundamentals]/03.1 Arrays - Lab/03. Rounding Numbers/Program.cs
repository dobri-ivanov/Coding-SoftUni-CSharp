using System;
using System.Linq;

namespace _03._Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} => {(int)Math.Round(array[i], MidpointRounding.AwayFromZero)}");
                Console.WriteLine();
            }
        }
    }
}
