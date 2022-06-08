using System;

namespace _05._Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double price = 0;
            string type = "";
            string destination = "";


            //Conditionals
            if (season == "summer")
            {
                type = "Camp";
            }
            else if (season == "winter")
            {
                type = "Hotel";
            }

            if (budget == 100 || budget < 100)
            {
                if (season == "summer")
                {
                    price = budget * 0.30;
                }
                else if (season == "winter")
                {
                    price = budget * 0.70;
                }
                destination = "Bulgaria";
            }
            else if (budget == 1000 || budget < 1000)
            {
                if (season == "summer")
                {
                    price = budget * 0.40;
                }
                else if (season == "winter")
                {
                    price = budget * 0.80;
                }
                destination = "Balkans";
            }
            else if (budget > 1000)
            {
                price = budget * 0.90;
                destination = "Europe";
                type = "Hotel";
            }

            //Output
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{type} - {price:f2}");
        }
    }
}
