using System;

namespace _10._Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int n = int.Parse(Console.ReadLine());

            //Loop
            int evenSum = 0;
            int oddSum = 0;

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += number;
                }
                else
                {
                    oddSum += number;
                }
            }

            //Conditionals
            if (evenSum == oddSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {evenSum}");
            }
            else
            {
                int diff = Math.Abs(evenSum - oddSum);
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
