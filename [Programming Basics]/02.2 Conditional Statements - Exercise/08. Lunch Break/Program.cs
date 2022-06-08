using System;

namespace _08._Lunch_Break
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            string nameOfSerial = Console.ReadLine();
            int durationOfSerial = int.Parse(Console.ReadLine());
            int durationOfBreak = int.Parse(Console.ReadLine());

            //Caclculations
            double durationOfLunch = durationOfBreak / 8.00;
            double durationOfChilling = durationOfBreak / 4.00;
            double freeTime = durationOfBreak - durationOfLunch - durationOfChilling;

            //Conditionals
            if (freeTime >= durationOfSerial)
            {
                double timeLeft = Math.Ceiling(freeTime - durationOfSerial);
                Console.WriteLine($"You have enough time to watch {nameOfSerial} and left with {timeLeft} minutes free time.");

            }
            else
            {
                double timeInNeed = Math.Ceiling(durationOfSerial - freeTime);
                Console.WriteLine($"You don't have enough time to watch {nameOfSerial}, you need {timeInNeed} more minutes.");
            }
        }
    }
}
