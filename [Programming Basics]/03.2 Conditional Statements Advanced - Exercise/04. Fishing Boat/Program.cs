using System;

namespace _04._Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            //Static data
            double rentSpring = 3000.00;
            double rentSummerAndAutumn = 4200.00;
            double rentWinter = 2600.00;

            //Input
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermans = int.Parse(Console.ReadLine());

            double priceForRent = 0;

            //Conditionals
            if (season == "Spring")
            {
                priceForRent = rentSpring;
            }
            else if (season == "Summer" || season == "Autumn")
            {
                priceForRent = rentSummerAndAutumn;
            }
            else if (season == "Winter")
            {
                priceForRent = rentWinter;
            }

            if (fishermans <= 6)
            {
                priceForRent *= 0.90;
            }
            else if (fishermans > 6 && fishermans <= 11)
            {
                priceForRent *= 0.85;
            }
            else if (fishermans > 11)
            {
                priceForRent *= 0.75;
            }

            if (fishermans % 2 == 0 && season != "Autumn")
            {
                priceForRent *= 0.95;
            }

            //Output
            if (priceForRent <= budget)
            {
                double moneyLeft = budget - priceForRent;
                Console.WriteLine($"Yes! You have {moneyLeft:f2} leva left.");
            }
            else
            {
                double moneyInNeed = priceForRent - budget;
                Console.WriteLine($"Not enough money! You need {moneyInNeed:f2} leva.");
            }

        }
    }
}
