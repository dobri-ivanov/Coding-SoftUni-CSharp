using System;

namespace _03._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            double currentBalance = balance;
            bool notify = true;

            while (true)
            {
                string text = Console.ReadLine();
                if (text == "Game Time")
                {
                    break;
                }

                if (text == "OutFall 4")
                {
                    if (currentBalance >= 39.99)
                    {
                        currentBalance -= 39.99;
                        Console.WriteLine($"Bought {text}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (text == "CS: OG")
                {

                    if (currentBalance >= 15.99)
                    {
                        currentBalance -= 15.99;
                        Console.WriteLine($"Bought {text}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (text == "Zplinter Zell")
                {

                    if (currentBalance >= 19.99)
                    {
                        currentBalance -= 19.99;
                        Console.WriteLine($"Bought {text}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (text == "Honored 2")
                {

                    if (currentBalance >= 59.99)
                    {
                        currentBalance -= 59.99;
                        Console.WriteLine($"Bought {text}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (text == "RoverWatch")
                {

                    if (currentBalance >= 29.99)
                    {
                        currentBalance -= 29.99;
                        Console.WriteLine($"Bought {text}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (text == "RoverWatch Origins Edition")
                {

                    if (currentBalance >= 39.99)
                    {
                        currentBalance -= 39.99;
                        Console.WriteLine($"Bought {text}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
                if (currentBalance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    notify = false;
                    break;
                }

            }
            if (notify)
            {
                Console.WriteLine($"Total spent: ${balance - currentBalance:f2}. Remaining: ${currentBalance:f2}");
            }
        }
    }
}
