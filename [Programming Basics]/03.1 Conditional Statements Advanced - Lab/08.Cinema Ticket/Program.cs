using System;

namespace _08.Cinema_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            string day = Console.ReadLine();

            double price = 0.00;
            //Conditionals
            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Friday":
                    price = 12;
                    break;
                case "Wednesday":
                case "Thursday":
                    price = 14;
                    break;
                case "Saturday":
                case "Sunday":
                    price = 16;
                    break;
                default:
                    break;
            }

            //Ouput
            Console.WriteLine(price);

        }
    }
}
