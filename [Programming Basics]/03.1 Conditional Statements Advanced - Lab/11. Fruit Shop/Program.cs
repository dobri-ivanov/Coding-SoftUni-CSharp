using System;

namespace _11._Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double price = 0.00;
            bool isWorkingDay = day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday";
            bool isWeekendDay = day == "Saturday" || day == "Sunday";

            //Conditionals
            switch (fruit)
            {
                case "banana":
                    if (isWorkingDay)
                    {
                        price = 2.50;
                        Console.WriteLine($"{price * quantity:f2}");
                    }
                    else if (isWeekendDay)
                    {
                        price = 2.70;
                        Console.WriteLine($"{price * quantity:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "apple":
                    if (isWorkingDay)
                    {
                        price = 1.20;
                        Console.WriteLine($"{price * quantity:f2}");
                    }
                    else if (isWeekendDay)
                    {
                        price = 1.25;
                        Console.WriteLine($"{price * quantity:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "orange":
                    if (isWorkingDay)
                    {
                        price = 0.85;
                        Console.WriteLine($"{price * quantity:f2}");
                    }
                    else if (isWeekendDay)
                    {
                        price = 0.90;
                        Console.WriteLine($"{price * quantity:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "grapefruit":
                    if (isWorkingDay)
                    {
                        price = 1.45;
                        Console.WriteLine($"{price * quantity:f2}");
                    }
                    else if (isWeekendDay)
                    {
                        price = 1.60;
                        Console.WriteLine($"{price * quantity:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "kiwi":
                    if (isWorkingDay)
                    {
                        price = 2.70;
                        Console.WriteLine($"{price * quantity:f2}");
                    }
                    else if (isWeekendDay)
                    {
                        price = 3.00;
                        Console.WriteLine($"{price * quantity:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "pineapple":
                    if (isWorkingDay)
                    {
                        price = 5.50;
                        Console.WriteLine($"{price * quantity:f2}");
                    }
                    else if (isWeekendDay)
                    {
                        price = 5.60;
                        Console.WriteLine($"{price * quantity:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "grapes":
                    if (isWorkingDay)
                    {
                        price = 3.85;
                        Console.WriteLine($"{price * quantity:f2}");
                    }
                    else if (isWeekendDay)
                    {
                        price = 4.20;
                        Console.WriteLine($"{price * quantity:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
