using System;

namespace _03._New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            string typeflowers = Console.ReadLine();
            int flowers = int.Parse(Console.ReadLine());
            int buget = int.Parse(Console.ReadLine());
            double total = 0.00;

            //Calculation
            if (typeflowers == "Roses")
            {
                if (flowers > 80)
                {
                    int price = (flowers * 5);
                    total = price - price * 0.10;
                }
                else
                {
                    total = (flowers * 5);
                }
            }
            else if (typeflowers == "Dahlias")
            {
                if (flowers > 90)
                {
                    double price = flowers * 3.80;
                    total = price - price * 0.15;
                }
                else

                    total = flowers * 3.80;
            }
            else if (typeflowers == "Tulips")
            {
                if (flowers > 80)
                {
                    double price = flowers * 2.80;
                    total = price - price * 0.15;
                }
                else
                {
                    total = flowers * 2.80;
                }
            }
            else if (typeflowers == "Narcissus")
            {
                if (flowers < 120)
                {
                    int price = flowers * 3;
                    total = price + price * 0.15;
                }
                else
                {
                    total = flowers * 3;
                }

            }
            else if (typeflowers == "Gladiolus")
            {
                if (flowers < 80)
                {
                    double price = flowers * 2.50;
                    total = price + price * 0.20;
                }
                else
                {
                    total = flowers * 2.50;
                }
            }
            //Output
            if (buget >= total)
            {
                double levaLeft = buget - total;
                Console.WriteLine($"Hey, you have a great garden with {flowers} {typeflowers} and {levaLeft:f2} leva left.");
            }
            else
            {
                double moneyInNeed = total - buget;
                Console.WriteLine($"Not enough money, you need {moneyInNeed:f2} leva more.");

            }

        }
    }
}
