using System;

namespace _01._USD_to_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double usd = double.Parse(Console.ReadLine());

            //Calculation
            double bgn = usd * 1.79549;

            //Output
            Console.WriteLine($"{bgn:f2}");
        }
    }
}
