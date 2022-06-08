using System;

namespace _06._Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Static data
            double priceOfPlastic = 1.50;
            double priceOfPaint = 14.50;
            double priceOfWater = 5.00;
            double bag = 0.40;

            //Input
            int plastic = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int litres = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            //Calcualtion
            double sumPlastic = priceOfPlastic * (plastic + 2);
            double addiction = paint * 0.10;
            double sumOfPaint = priceOfPaint * (paint + addiction);
            double sumOfWater = priceOfWater * litres;
            double totalSum = sumPlastic + sumOfPaint + sumOfWater + bag;
            double priceForWorkPerHour = totalSum * 0.30;
            double sumForWork = priceForWorkPerHour * hours;
            double totalWithWork = totalSum + sumForWork;

            //Output
            Console.WriteLine(totalWithWork);


        }
    }
}
