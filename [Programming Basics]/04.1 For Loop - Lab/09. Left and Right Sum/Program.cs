using System;

namespace _09._Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input 
            int n = int.Parse(Console.ReadLine());

            //Loops
            int rightSum = 0;
            int leftSum = 0;
            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                rightSum += number;
            }

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                leftSum += number;
            }

            //Conditionals
            if (rightSum == leftSum)
            {
                Console.WriteLine($"Yes, sum = {rightSum}");
            }
            else
            {
                int diff = Math.Abs(rightSum - leftSum);
                Console.WriteLine($"No, diff = {diff}");
            }
        }
    }
}
