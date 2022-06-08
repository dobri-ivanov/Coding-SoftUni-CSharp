using System;

namespace _09._Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            //Calculation
            int capacity = lenght * width * height;
            double litres = capacity * 0.001;
            double totalPercent = percent * 0.01;
            double totalLitres = litres * (1 - totalPercent);

            //Output
            Console.WriteLine(totalLitres);


        }
    }
}
