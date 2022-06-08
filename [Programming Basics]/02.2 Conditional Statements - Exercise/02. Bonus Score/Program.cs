using System;

namespace _02._Bonus_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int number = int.Parse(Console.ReadLine());

            double points = 0.0;
            //Conditionals
            if (number <= 100)
            {
                points += 5;
            }
            else if (number > 1000)
            {
                points += number * 0.10;
            }
            else
            {
                points += number * 0.20;
            }

            if (number % 2 == 0)
            {
                points += 1;
            }
            else if (number % 10 == 5)
            {
                points += 2;
            }

            //Output
            Console.WriteLine(points);
            Console.WriteLine(number + points);
        }
    }
}
