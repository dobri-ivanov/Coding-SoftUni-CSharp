using System;

namespace _03._Deposit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double DepositSum = double.Parse(Console.ReadLine());
            int Months = int.Parse(Console.ReadLine());
            double Prcent = double.Parse(Console.ReadLine());

            //Calculation
            double InterestSum = DepositSum * Prcent * 0.01;
            double Sum = InterestSum / 12;
            double Total = DepositSum + Months * Sum;

            //Output
            Console.WriteLine($"{Total:f2}");


        }
    }
}
