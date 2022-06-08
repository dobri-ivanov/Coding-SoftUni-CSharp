using System;

namespace Ozelenqvane
{
    class Program
    {
        static void Main(string[] args)
        {
            double meters = double.Parse(Console.ReadLine());
            double all = meters * (7.61);
            double discount = (0.18) * all;
            double final = all - discount;
            Console.WriteLine("The finale price is: " + final + " lv.");
            Console.WriteLine("The discount is: " + discount + " lv.");

        }
    }
}
