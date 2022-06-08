using System;

namespace _02._Radians_to_Degrees
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double radians = double.Parse(Console.ReadLine());

            //Calculation
            double degrees = radians * 180 / Math.PI;

            //Output
            Console.WriteLine(Math.Round(degrees));
        }
    }
}
