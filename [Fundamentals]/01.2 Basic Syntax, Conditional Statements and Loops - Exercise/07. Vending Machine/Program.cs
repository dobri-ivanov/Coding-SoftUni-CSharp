using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double money = 0;
            double coins= 0;

            while (input != "Start")
            {
                coins = double.Parse(input);
                if (coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2)
                {
                    money += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
                input = Console.ReadLine();
            }

            while (true)
            {
                input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                if (input == "Nuts")
                {
                    if (money >= 2.0)
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                        money -= 2.0;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Water")
                {
                    if (money >= 0.7)
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                        money -= 0.7;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Crisps")
                {
                    if (money >= 1.5)
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                        money -= 1.5;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Soda")
                {
                    if (money >= 0.8)
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                        money -= 0.8;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Coke")
                {
                    if (money >= 1.0)
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                        money -= 1.0;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
            }
            Console.WriteLine($"Change: {money:f2}");

        }
    }
}
