using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            int people = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();
            double discout = 0;
            double price = 0;

            //Price
            if (day == "Friday")
            {
                if (type == "Students")
                {
                    price = 8.45;
                }
                else if (type == "Business")
                {
                    price = 10.90;
                }
                else
                {
                    price = 15;
                }
            }
            else if (day == "Saturday")
            {
                if (type == "Students")
                {
                    price = 9.80;
                }
                else if (type == "Business")
                {
                    price = 15.60;
                }
                else
                {
                    price = 20;
                }
            }
            else if (day == "Sunday")
            {
                if (type == "Students")
                {
                    price = 10.46;
                }
                else if (type == "Business")
                {
                    price = 16;
                }
                else
                {
                    price = 22.50;
                }
            }

            //Discount
            if (type == "Students")
            {
                if (people >= 30)
                {
                    discout = 0.15;
                }
            }
            else if (type == "Business")
            {
                if (people >= 100)
                {
                    people -= 10;
                }
            }
            else
            {
                if (people >= 10 && people <= 20)
                {
                    discout = 0.05;
                }
            }

            double sumWithoutDiscount = people * price;
            double totalSum = sumWithoutDiscount - (sumWithoutDiscount * discout);

            Console.WriteLine($"Total price: {totalSum:f2}");
        }
    }
}
