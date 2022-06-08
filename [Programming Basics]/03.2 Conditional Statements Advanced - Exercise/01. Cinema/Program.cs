using System;

namespace _01._Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int colums = int.Parse(Console.ReadLine());

            double totalPrice = 0.0;
            if (type == "Premiere")
            {
                totalPrice = rows * colums * 12.00;
            }
            else if(type == "Normal")
            {
                totalPrice = rows * colums * 7.50;
            }
            else if (type == "Discount")
            {
                totalPrice = rows * colums * 5.00;
            }
            Console.WriteLine($"{totalPrice:f2} leva");

        }
    }
}
