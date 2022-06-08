using System;

namespace _03._Even_or_Odd
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int number = int.Parse(Console.ReadLine());

            //Conditional
            if (number % 2 == 0)
            {
                Console.WriteLine("even");
            }
            else
            {
                Console.WriteLine("odd");
            }
        }
    }
}
