using System;

namespace _06._Number_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double number = double.Parse(Console.ReadLine());

            //Conditional
            bool isInRange = number >= -100 && number <= 100 && number != 0;
            if (isInRange)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }
    }
}
