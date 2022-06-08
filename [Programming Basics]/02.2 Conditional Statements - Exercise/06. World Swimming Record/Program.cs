using System;

namespace _06._World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double recordInSeconds = double.Parse(Console.ReadLine());
            double recordInMeters = double.Parse(Console.ReadLine());
            double secondsForOneMeter = double.Parse(Console.ReadLine());

            //Calculations
            double resistance = Math.Floor(recordInMeters / 15) * 12.5;
            double seconds = recordInMeters * secondsForOneMeter;
            double finalSeconds = seconds + resistance;

            if (finalSeconds < recordInSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {finalSeconds:f2} seconds.");
            }
            else
            {
                double secondsInNeed = finalSeconds - recordInSeconds;
                Console.WriteLine($"No, he failed! He was {secondsInNeed:f2} seconds slower.");
            }
        }
    }
}
