using System;

namespace _04._Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            //Calclucaltions
            int totalminutes = hours * 60 + minutes;
            totalminutes += 30;

            hours = totalminutes / 60;
            minutes = totalminutes % 60;

            if (hours == 24)
            {
                hours = 0;
            }

            //Output
            if (minutes <= 9)
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
