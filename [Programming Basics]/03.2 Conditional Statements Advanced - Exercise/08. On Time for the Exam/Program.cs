using System;

namespace _08._On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int examHours = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            //Calculations
            int examTime = examHours * 60 + examMinutes;
            int time = hours * 60 + minutes;

            bool isOnTime = examTime - time <= 30 && examTime - time >= 0;
            bool isEarly = examTime - time > 30;
            bool isLate = time - examTime > 0;

            //Conditionals
            if (isOnTime)
            {
                int minutesBefore = examTime - time;
                if (minutesBefore != 0)
                {
                    Console.WriteLine("On time");
                    Console.WriteLine($"{minutesBefore} minutes before the start");
                }
                else
                {
                    Console.WriteLine("On time");
                }
            }
            else if (isEarly)
            {
                Console.WriteLine("Early");
                int minutesBefore = examTime - time;
                if (minutesBefore >= 60)
                {
                    int hoursBefore = minutesBefore / 60;
                    int minBefore = minutesBefore % 60;
                    if (minBefore < 10)
                    {
                        Console.WriteLine($"{hoursBefore}:0{minBefore} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hoursBefore}:{minBefore} hours before the start");
                    }
                }
                else
                {
                    Console.WriteLine($"{minutesBefore} minutes before the start");
                }
            }
            else if (isLate)
            {
                Console.WriteLine("Late");
                int minutesAfter = time - examTime;
                if (minutesAfter >= 60)
                {
                    int hoursBefore = minutesAfter / 60;
                    int minBefore = minutesAfter % 60;
                    if (minBefore < 10)
                    {
                        Console.WriteLine($"{hoursBefore}:0{minBefore} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hoursBefore}:{minBefore} hours after the start");
                    }
                }
                else
                {
                    Console.WriteLine($"{minutesAfter} minutes after the start");
                }
            }
        }
    }
}
