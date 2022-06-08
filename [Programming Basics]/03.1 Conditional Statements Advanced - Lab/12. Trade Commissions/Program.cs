using System;

namespace _12._Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            //Conditional
            double percent = 0.00;
            if (city == "Sofia")
            {
                if (sales >= 0 && sales <= 500)
                {
                    percent = 0.05;
                    Console.WriteLine($"{sales * percent:f2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    percent = 0.07;
                    Console.WriteLine($"{sales * percent:f2}");
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    percent = 0.08;
                    Console.WriteLine($"{sales * percent:f2}");
                }
                else if (sales > 10000)
                {
                    percent = 0.12;
                    Console.WriteLine($"{sales * percent:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }

            }
            else if (city == "Varna")
            {
                if (sales >= 0 && sales <= 500)
                {
                    percent = 0.045;
                    Console.WriteLine($"{sales * percent:f2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    percent = 0.075;
                    Console.WriteLine($"{sales * percent:f2}");
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    percent = 0.10;
                    Console.WriteLine($"{sales * percent:f2}");
                }
                else if (sales > 10000)
                {
                    percent = 0.13;
                    Console.WriteLine($"{sales * percent:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (city == "Plovdiv")
            {
                if (sales >= 0 && sales <= 500)
                {
                    percent = 0.055;
                    Console.WriteLine($"{sales * percent:f2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    percent = 0.08;
                    Console.WriteLine($"{sales * percent:f2}");
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    percent = 0.12;
                    Console.WriteLine($"{sales * percent:f2}");
                }
                else if (sales > 10000)
                {
                    percent = 0.145;
                    Console.WriteLine($"{sales * percent:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }

        }
    }
}
