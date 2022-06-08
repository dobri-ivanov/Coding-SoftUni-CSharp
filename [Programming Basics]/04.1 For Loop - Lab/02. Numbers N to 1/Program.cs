using System;

namespace _02._Numbers_N_to_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int n = int.Parse(Console.ReadLine());

            //Loop
            for (int i = n; i >= 1; i--)
            {
                Console.WriteLine(i);
            }

        }
    }
}
