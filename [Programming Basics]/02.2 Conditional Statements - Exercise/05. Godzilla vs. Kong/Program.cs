using System;

namespace _05._Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double budget = double.Parse(Console.ReadLine());
            int numberOfStatist = int.Parse(Console.ReadLine());
            double priceOfClothing = double.Parse(Console.ReadLine());

            //Calculations
            double priceOfDecor = budget * 0.10;
            if (numberOfStatist > 150)
            {
                priceOfClothing -= priceOfClothing * 0.10;
            }
            double sumOfClothing = numberOfStatist * priceOfClothing;
            double totalSum = sumOfClothing + priceOfDecor;

            if (totalSum <= budget)
            {
                double leftMoney = budget - totalSum;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {leftMoney:f2} leva left.");
            }
            else
            {
                double moneyInNeed = totalSum - budget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {moneyInNeed:f2} leva more.");
            }
        }
    }
}
