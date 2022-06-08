using System;

namespace _03._Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            //Calculations
            int totalTime = hours * 60 + minutes + 15;
            hours = totalTime / 60;
            minutes = totalTime % 60;

            //Conditionals
            if (hours >= 24)
            {
                hours -= 24;
            }

            if (minutes < 10)
            {
                Console.WriteLine($"{hours}:0{minutes}");
            }
            else
            {
                Console.WriteLine($"{hours}:{minutes}");
            }

        }
    }
}
