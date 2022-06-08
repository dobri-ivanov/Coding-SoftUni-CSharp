using System;

namespace _01._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", };
            int n = int.Parse(Console.ReadLine());
            if (n > 0 && n <= 7)
            {
                Console.WriteLine(days[n - 1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
