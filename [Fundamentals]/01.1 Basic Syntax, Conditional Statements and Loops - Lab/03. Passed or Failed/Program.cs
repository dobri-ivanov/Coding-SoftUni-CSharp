using System;

namespace _03._Passed_or_Failed
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
            else
            {
                Console.WriteLine("Failed!");
            }

        }
    }
}
