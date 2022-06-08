using System;

namespace _02._Passed
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double number = double.Parse(Console.ReadLine());

            //Conditional
            if (number >= 3.00)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}
