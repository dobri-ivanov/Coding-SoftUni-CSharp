using System;

namespace _09._Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            //Constant data
            const double priceForRoom = 18.00;
            const double priceForApart = 25.00;
            const double priceForPreApart = 35.00;

            //Input
            int days = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string grade = Console.ReadLine();

            //Conditionals
            double discount;

            if (type == "apartment")
            {
                if (days < 10)
                {
                    discount = 0.30;
                }
                else if (days >= 10 && days <= 15)
                {
                    discount = 0.35;
                }
                else
                {
                    discount = 0.50;
                }
            }
            else if (type == "president apartment")
            {
                if (days < 10)
                {
                    discount = 0.10;
                }
                else if (days >= 10 && days <= 15)
                {
                    discount = 0.15;
                }
                else
                {
                    discount = 0.20;
                }
            }
            else
            {
                discount = 0.00;
            }

            double sum;
            if (type == "room for one person")
            {
                sum = priceForRoom * (days - 1);
            }
            else if (type == "apartment")
            {
                sum = priceForApart * (days - 1);
            }
            else
            {
                sum = priceForPreApart * (days - 1);
            }

            double sumWithDiscount = sum - (sum * discount);
            double sumWithGrade = 0;

            if (grade == "positive")
            {
                sumWithGrade = sumWithDiscount + sumWithDiscount * 0.25;
            }
            else if (grade == "negative")
            {
                sumWithGrade = sumWithDiscount - sumWithDiscount * 0.10;
            }
            Console.WriteLine($"{sumWithGrade:f2}");
        }
    }
}
