using System;

namespace _06._Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double n1 = int.Parse(Console.ReadLine());
            double n2 = int.Parse(Console.ReadLine());
            char symbol = char.Parse(Console.ReadLine());

            //Conditionals
            if (symbol == '+')
            {
                string type;
                double sum = n1 + n2;
                if (sum % 2 == 0)
                {
                    type = "even";
                }
                else
                {
                    type = "odd";
                }
                Console.WriteLine($"{n1} + {n2} = {sum} - {type}");
            }
            else if (symbol == '-')
            {
                string type;
                double sum = n1 - n2;
                if (sum % 2 == 0)
                {
                    type = "even";
                }
                else
                {
                    type = "odd";
                }
                Console.WriteLine($"{n1} - {n2} = {sum} - {type}");
            }
            else if (symbol == '*')
            {
                string type;
                double sum = n1 * n2;
                if (sum % 2 == 0)
                {
                    type = "even";
                }
                else
                {
                    type = "odd";
                }
                Console.WriteLine($"{n1} * {n2} = {sum} - {type}");
            }
            else if (symbol == '/')
            {
                if (n2 != 0)
                {
                    double sum = n1 / n2;
                    Console.WriteLine($"{n1} / {n2} = {sum:f2}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
            }
            else if (symbol == '%')
            {
                if (n2 != 0)
                {
                    double sum = n1 % n2;
                    Console.WriteLine($"{n1} % {n2} = {sum}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
            }
        }
    }
}
