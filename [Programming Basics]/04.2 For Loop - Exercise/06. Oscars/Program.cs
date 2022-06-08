using System;

namespace _06._Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            string name = Console.ReadLine();
            double points = double.Parse(Console.ReadLine());
            int judgeMans = int.Parse(Console.ReadLine());

            //Loop
            for (int i = 1; i <= judgeMans; i++)
            {
                //Input
                string judgeName = Console.ReadLine();
                double extraPoints = double.Parse(Console.ReadLine());

                points += judgeName.Length * extraPoints / 2;

                //Conditional
                if (points > 1250.5)
                {
                    Console.WriteLine($"Congratulations, {name} got a nominee for leading role with {points:f1}!");
                    break;
                }

            }

            //Conditional
            if (points <= 1250.5)
            {
                Console.WriteLine($"Sorry, {name} you need {1250.5 - points:f1} more!");
            }
        }
    }
}
