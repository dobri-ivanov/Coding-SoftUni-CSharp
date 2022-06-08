using System;

namespace _08._Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int tax = int.Parse(Console.ReadLine());

            //Prices
            double priceOfShoes = tax - (tax * 0.40);
            double priceOfWear = priceOfShoes - (priceOfShoes * 0.20);
            double priceOfBall = priceOfWear / 4;
            double priceOfAccessories = priceOfBall / 5;

            //Calculation
            double total = tax + priceOfShoes + priceOfWear + priceOfBall + priceOfAccessories;

            //Output
            Console.WriteLine(total);
        }
    }
}
