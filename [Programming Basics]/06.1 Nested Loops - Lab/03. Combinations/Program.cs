using System;

namespace _03._Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int number = int.Parse(Console.ReadLine());
            int counter = 0;

            //Loop
            for (int i = 0; i <= number; i++)
            {
                for (int j = 0; j <= number; j++)
                {
                    for (int h = 0; h <= number; h++)
                    {
                        if (i + j + h == number)
                        {
                            counter++;
                        }
                    }
                }
            }

            //Output
            Console.WriteLine(counter);
        }
    }
}
