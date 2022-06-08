using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            double account = 0;
            while (true)
            {
                string text = Console.ReadLine();
                if (text == "NoMoreMoney")
                {
                    break;
                }
                double num = double.Parse(text);

                if (num < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                account += num;
                Console.WriteLine($"Increase: {num:f2}");
            }
            Console.WriteLine($"Total: {account:f2}");
        }
    }
}
