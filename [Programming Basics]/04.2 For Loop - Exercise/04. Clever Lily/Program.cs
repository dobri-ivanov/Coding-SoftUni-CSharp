using System;

namespace _04._Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int age = int.Parse(Console.ReadLine());
            double price1 = double.Parse(Console.ReadLine());
            double priceForToys = double.Parse(Console.ReadLine());
            double money = 0;
            int toys = 0;
            int counter = 1;
            //Loop
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    money += counter * 10;
                    counter++;
                    money--;
                }
                else
                {
                    toys++;
                }
            }
            double sumOfToys = toys * priceForToys;
            double totalMoney = money + sumOfToys;

            if (totalMoney >= price1)
            {
                double moneyLeft = totalMoney - price1;
                Console.WriteLine($"Yes! {moneyLeft:f2}");
            }
            else
            {
                double moneyInNeed = price1 - totalMoney;
                Console.WriteLine($"No! {moneyInNeed:f2}");
            }
        }
    }
}
