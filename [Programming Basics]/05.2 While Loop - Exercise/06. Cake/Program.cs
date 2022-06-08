using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int weidth = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());

            //Calculations
            int cake = weidth * lenght;

            //Loop
            string text = Console.ReadLine();
            while (text != "STOP")
            {
                int peaces = int.Parse(text);
                cake -= peaces;
                if (cake < 0)
                {
                    break;
                }
                text = Console.ReadLine();
            }

            //Output
            if (cake < 0)
            {
                
                Console.WriteLine($"No more cake left! You need {Math.Abs(cake)} pieces more.");
            }
            else
            {
                Console.WriteLine($"{cake} pieces are left.");
            }

        }
    }
}
