using System;

namespace _01._Cooking_Masterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            float budget = float.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            float priceOfFlour = float.Parse(Console.ReadLine());
            float priceOfEgg = float.Parse(Console.ReadLine());
            float priceOfApron = float.Parse(Console.ReadLine());

            double sumOfAprons = priceOfApron * (students + Math.Ceiling(students * 0.20));
            double sumOfEggs = priceOfEgg * 10 * students;
            double sumOfFlour = priceOfFlour * (students - students / 5);

            double sum = sumOfFlour + sumOfEggs + sumOfAprons;

            if (sum <= budget)
            {
                Console.WriteLine($"Items purchased for {sum:f2}$.");
            }
            else
            {
                Console.WriteLine($"{sum - budget:f2}$ more needed.");
            }

        }
    }
}
