using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double moneyInNeed = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());
            int countDays = 0;
            int spendDaysCount = 0;

            //Loop
            while (availableMoney < moneyInNeed && spendDaysCount < 5)
            {
                countDays++;
                string type = Console.ReadLine();
                double sum = double.Parse(Console.ReadLine());

                if (type == "save")
                {
                    availableMoney += sum;
                    spendDaysCount = 0;
                }
                else if (type == "spend")
                {
                    availableMoney -= sum;
                    if (availableMoney < 0)
                    {
                        availableMoney = 0;
                    }
                    spendDaysCount++;
                }
            }

            if (spendDaysCount == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(countDays);
            }
            if (availableMoney >= moneyInNeed)
            {
                Console.WriteLine($"You saved the money for {countDays} days.");
            }
        }
    }
}
