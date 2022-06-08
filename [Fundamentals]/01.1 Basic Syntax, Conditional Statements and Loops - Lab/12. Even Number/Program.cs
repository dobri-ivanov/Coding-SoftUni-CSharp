using System;

namespace _12._Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int n = int.Parse(Console.ReadLine());

            //Loop
            while (n % 2 != 0)
            {
                Console.WriteLine("Please write an even number.");
                n = int.Parse(Console.ReadLine());
            }

            if (n % 2 == 0)
            {
                Console.WriteLine($"The number is: {Math.Abs(n)}");
            }
        }
    }
}
