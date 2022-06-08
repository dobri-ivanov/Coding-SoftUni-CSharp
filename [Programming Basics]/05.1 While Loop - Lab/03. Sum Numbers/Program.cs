using System;

namespace _03._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            //Loop
            while (sum < n)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;
            }

            //Output
            Console.WriteLine(sum);
        }
    }
}
