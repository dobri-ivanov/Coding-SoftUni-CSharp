using System;

namespace _04._Even_Powers_of_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int n = int.Parse(Console.ReadLine());

            //Loop
            for (int i = 0; i <= n; i += 2)
            {
                Console.WriteLine(Math.Pow(2,i));
            }
        }
    }
}
