using System;

namespace _03._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double n = int.Parse(Console.ReadLine());
            int countTo200 = 0;
            int countTo399 = 0;
            int countTo599 = 0;
            int countTo799 = 0;
            int countTo1000 = 0;

            //Loop
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 200)
                {
                    countTo200++;
                }
                else if (num < 400)
                {
                    countTo399++;
                }
                else if (num < 600)
                {
                    countTo599++;
                }
                else if (num < 800)
                {
                    countTo799++;
                }
                else if (num <= 1000)
                {
                    countTo1000++;
                }

            }
            double percentTo200 = countTo200 / n * 100;
            double percentTo399 = countTo399 / n * 100;
            double percentTo599 = countTo599 / n * 100;
            double percentTo799 = countTo799 / n * 100;
            double percentTo1000 = countTo1000 / n * 100;

            //Output
            Console.WriteLine($"{percentTo200:f2}%");
            Console.WriteLine($"{percentTo399:f2}%");
            Console.WriteLine($"{percentTo599:f2}%");
            Console.WriteLine($"{percentTo799:f2}%");
            Console.WriteLine($"{percentTo1000:f2}%");

        }
    }
}
