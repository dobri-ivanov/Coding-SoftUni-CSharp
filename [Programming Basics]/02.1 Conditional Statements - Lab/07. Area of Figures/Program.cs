using System;

namespace _07._Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            string shape = Console.ReadLine();

            //Conditional 
            if (shape == "square")
            {
                double side = double.Parse(Console.ReadLine());
                Console.WriteLine($"{side * side:f3}");
            }
            else if (shape == "rectangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double sideB = double.Parse(Console.ReadLine());
                Console.WriteLine($"{sideA * sideB:f3}");
            }
            else if (shape == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                Console.WriteLine($"{Math.Pow(r,2)*Math.PI:f3}");
            }
            else if (shape == "triangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double lenght = double.Parse(Console.ReadLine());
                Console.WriteLine($"{(sideA * lenght) / 2:f3}");
            }
        }
    }
}
