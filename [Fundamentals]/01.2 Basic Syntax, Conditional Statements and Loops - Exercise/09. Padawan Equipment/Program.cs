using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double moneyHas = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double ropePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double numberOfLightsaber = Math.Ceiling(students + (students * 0.10));               
            double numberOfBelt = students - (students / 6);
            double numberOfRope = students;

            double lightsaberSum = lightsaberPrice * numberOfLightsaber;
            double beltSum = beltPrice * numberOfBelt;
            double ropeSum = ropePrice * numberOfRope;

            double totalSum = lightsaberSum + beltSum + ropeSum;

            if (moneyHas >= totalSum)
            {
                Console.WriteLine($"The money is enough - it would cost {totalSum:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalSum - moneyHas:f2}lv more.");
            }

        }
    }
}