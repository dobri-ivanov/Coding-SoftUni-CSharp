using System;

namespace _05._Supplies_for_School
{
    class Program
    {
        static void Main(string[] args)
        {
            //Static data
            double priceOfPens = 5.80;
            double priceOfMarkers = 7.20;
            double priceOfChemical = 1.20;

            //Input
            int numberOfPens = int.Parse(Console.ReadLine());
            int numberOfMarkers = int.Parse(Console.ReadLine());
            int litresOFChemical = int.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine()) / 100.00;

            //Calcualtion
            double sumOfPens = priceOfPens * numberOfPens;
            double sumOFMarkers = priceOfMarkers * numberOfMarkers;
            double sumOfChemical = priceOfChemical * litresOFChemical;
            double totalSum = sumOfPens + sumOFMarkers + sumOfChemical;
            double totalWithDiscount = totalSum - (totalSum * discount);

            //Output
            Console.WriteLine(totalWithDiscount);


        }
    }
}
