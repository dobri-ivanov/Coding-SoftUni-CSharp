using System;

namespace _07._Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            //Static data
            double priceOfGpu = 250;

            //Input
            double budget = double.Parse(Console.ReadLine());
            int numberOfGpu = int.Parse(Console.ReadLine());
            int numberOfCpu = int.Parse(Console.ReadLine());
            int numberOfRam = int.Parse(Console.ReadLine());

            //Calculations
            double sumOfGpu = numberOfGpu * priceOfGpu;
            double priceOfCpu = sumOfGpu * 0.35;
            double priceOfRam = sumOfGpu * 0.10;
            double sumOfCpu = numberOfCpu * priceOfCpu;
            double sumOfRam = numberOfRam * priceOfRam;
            double totalSum = sumOfGpu + sumOfCpu + sumOfRam;

            //Conditionals
            if (numberOfGpu > numberOfCpu)
            {
                totalSum -= totalSum * 0.15;
            }
            if (budget >= totalSum)
            {
                double moneyLeft = budget - totalSum;
                Console.WriteLine($"You have {moneyLeft:f2} leva left!");
            }
            else
            {
                double moneyInNeed = totalSum - budget;
                Console.WriteLine($"Not enough money! You need {moneyInNeed:f2} leva more!");
            }
        }
    }
}
