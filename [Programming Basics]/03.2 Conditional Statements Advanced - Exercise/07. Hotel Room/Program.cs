using System;

namespace _07._Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double studioPrice = 0.00;
            double appPrice = 0.00;
            double studioDiscount = 0;
            double appDiscount = 0;

            if (month == "May" || month == "October")
            {
                studioPrice = 50.00;
                appPrice = 65.00;
            }
            else if (month == "June" || month == "September")
            {
                studioPrice = 75.20;
                appPrice = 68.70;
            }
            else if (month == "July" || month == "August")
            {
                studioPrice = 76.00;
                appPrice = 77.00;
            }

            if (nights > 7 && nights < 14)
            {
                if (month == "May" || month == "October")
                {
                    studioDiscount = 0.05;
                }
            }
            else if (nights > 14)
            {
                appDiscount = 0.10;
                if (month == "May" || month == "October")
                {
                    studioDiscount = 0.30;
                }
                else if (month == "June" || month == "September")
                {
                    studioDiscount = 0.20;
                }
            }

            double studioSum = studioPrice * nights;
            double appSum = appPrice * nights;
            double studioSumWithDiscount = studioSum - (studioSum * studioDiscount);
            double appSumWithDiscount = appSum - (appSum * appDiscount);

            //Output
            Console.WriteLine($"Apartment: {appSumWithDiscount:f2} lv.");
            Console.WriteLine($"Studio: {studioSumWithDiscount:f2} lv.");


        }
    }
}
