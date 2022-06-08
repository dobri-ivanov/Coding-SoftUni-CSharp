using System;

namespace _05._Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            //Loops
            double money;
            while (true)
            {
                string destination = Console.ReadLine();
                if (destination == "End")
                {
                    break;
                }
                double neededMoney = double.Parse(Console.ReadLine());
                money = 0;

                while (money < neededMoney)
                {
                    double incomeMoney = double.Parse(Console.ReadLine());
                    money += incomeMoney;
                }
                Console.WriteLine($"Going to {destination}!");
            }
        }
    }
}
