using System;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double @base = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            Console.WriteLine(PowerNumbers(@base, power));
        }

        static double PowerNumbers(double @base, int power)
        {
            return Math.Pow(@base, power);
        }
    }
}
