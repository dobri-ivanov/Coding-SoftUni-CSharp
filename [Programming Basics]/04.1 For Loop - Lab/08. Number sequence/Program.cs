using System;

namespace _08._Number_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int n = int.Parse(Console.ReadLine());
            int maxNum = int.MinValue;
            int minNum = int.MaxValue;

            //Loop
            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number > maxNum)
                {
                    maxNum = number;
                }
                if (number < minNum)
                {
                    minNum = number;
                }
            }

            //Output
            Console.WriteLine("Max number: " + maxNum);
            Console.WriteLine("Min number: " + minNum);
        }
    }
}
