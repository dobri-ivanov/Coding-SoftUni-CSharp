using System;
using System.Linq;

namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            foreach (var number in numbers)
            {
                double newNumber = number + number * 0.20;
                Console.WriteLine($"{newNumber:f2}");
            }
        }
    }
}
