using System;

namespace _08._Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double tournaments = int.Parse(Console.ReadLine());
            double startingPoints = int.Parse(Console.ReadLine());
            double wonTournaments = 0;
            double earnedPoints = 0;

            //Loop
            for (int i = 1; i <= tournaments; i++)
            {
                //Input
                string stage = Console.ReadLine();

                //Conditional
                if (stage == "W")
                {
                    earnedPoints += 2000;
                    wonTournaments++;
                }
                else if (stage == "F")
                {
                    earnedPoints += 1200;
                }
                else if (stage == "SF")
                {
                    earnedPoints += 720;
                }
            }

            //Calculations
            double averagePoints = earnedPoints / tournaments;
            double percentWonTournaments = wonTournaments / tournaments * 100;

            //Output
            Console.WriteLine($"Final points: {startingPoints + earnedPoints}");
            Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
            Console.WriteLine($"{percentWonTournaments:f2}%");
        }
    }
}
