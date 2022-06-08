using System;

namespace _07._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int n = int.Parse(Console.ReadLine());

            //Loop
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                int m = int.Parse(Console.ReadLine());
                sum += m;
            }

            //Output
            Console.WriteLine(sum);


        }
    }
}
