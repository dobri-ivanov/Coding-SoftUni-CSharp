using System;

namespace _07._Food_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            //Static data
            double priceForChicken = 10.35;
            double priceForFish = 12.40;
            double priceForVegans = 8.15;
            double delivery = 2.50;

            //Input
            int numberOFChickens = int.Parse(Console.ReadLine());
            int numberOfFishes = int.Parse(Console.ReadLine());
            int numberOfVegans = int.Parse(Console.ReadLine());

            //Calculation
            double sumForChickens = priceForChicken * numberOFChickens;
            double sumOfFishes = priceForFish * numberOfFishes;
            double sumOfVegans = priceForVegans * numberOfVegans;
            double sumOfAllMeats = sumForChickens + sumOfFishes + sumOfVegans;
            double dessert = sumOfAllMeats * 0.20;
            double total = sumOfAllMeats + dessert + delivery;

            //Output
            Console.WriteLine(total);


        }
    }
}
