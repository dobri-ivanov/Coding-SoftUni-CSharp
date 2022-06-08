using System;

namespace _04._Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            //Static data
            double priceOfMaze = 2.60;
            int priceOfDoles = 3;
            double priceOfBear = 4.10;
            double priceOfMinion = 8.20;
            int priceOfTruck = 2;

            //Input
            double priceOfVacantion = double.Parse(Console.ReadLine());
            int numberOfMaze = int.Parse(Console.ReadLine());
            int numberOfDoles = int.Parse(Console.ReadLine());
            int numberOfBears = int.Parse(Console.ReadLine());
            int numberOfMinions = int.Parse(Console.ReadLine());
            int numberOfTrucks = int.Parse(Console.ReadLine());

            int totalNumbers = numberOfMaze + numberOfDoles + numberOfBears + numberOfMinions + numberOfTrucks;

            //Calculations
            double sumOfMaze = numberOfMaze * priceOfMaze;
            double sumOfDols = numberOfDoles * priceOfDoles;
            double sumOfBears = numberOfBears * priceOfBear;
            double sumOfMinions = numberOfMinions * priceOfMinion;
            double sumOfTrucks = numberOfTrucks * priceOfTruck;

            double totalSum = sumOfMaze + sumOfDols + sumOfBears + sumOfMinions + sumOfTrucks;

            //Conditionals
            if (totalNumbers >= 50)
            {
                totalSum -= totalSum * 0.25;
            }
            totalSum -= totalSum * 0.10;

            if (priceOfVacantion <= totalSum)
            {
                double leftSum = totalSum - priceOfVacantion;
                Console.WriteLine($"Yes! {leftSum:f2} lv left.");
            }
            else
            {
                double leftSum = priceOfVacantion - totalSum;
                Console.WriteLine($"Not enough money! {leftSum:f2} lv needed.");
            }
        }
    }
}
