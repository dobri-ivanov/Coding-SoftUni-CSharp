using System;

namespace _07._Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            int price = 0;
            bool print = true;
            //Conditionals
            if (age >= 0 && age <= 18)
            {
                if (day == "Weekday")
                {
                    price = 12;
                }
                else if (day == "Weekend")
                {
                    price = 15;
                }
                else
                {
                    price = 5;
                }
            }
            else if (age >= 0 && age <= 64)
            {
                if (day == "Weekday")
                {
                    price = 18;
                }
                else if (day == "Weekend")
                {
                    price = 20;
                }
                else
                {
                    price = 12;
                }
            }
            else if (age >= 0 && age <= 122)
            {
                if (day == "Weekday")
                {
                    price = 12;
                }
                else if (day == "Weekend")
                {
                    price = 15;
                }
                else
                {
                    price = 10;
                }
            }
            else
            {
                print = false;
                Console.WriteLine("Error!");
            }

            if (print)
            {
                Console.WriteLine($"{price}$");
            }
        }
    }
}
