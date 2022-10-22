using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Energy_Drinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int currentCaffeineIntake = 0;
            Stack<int> caffeine = new Stack<int>();
            Queue<int> drinks = new Queue<int>();

            int[] caffeineInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] drinksInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int i = 0; i < caffeineInput.Length; i++)
            {
                caffeine.Push(caffeineInput[i]);
            }
            for (int i = 0; i < drinksInput.Length; i++)
            {
                drinks.Enqueue(drinksInput[i]);
            }
            while (true)
            {
                if (!caffeine.Any() || !drinks.Any())
                {
                    break;
                }

                int currentCaffeine = caffeine.Peek();
                int currentDrink = drinks.Peek();
                int sumOfDrink = currentCaffeine * currentDrink;
                if (sumOfDrink + currentCaffeineIntake <= 300)
                {
                    currentCaffeineIntake += sumOfDrink;
                    caffeine.Pop();
                    drinks.Dequeue();
                }
                else
                {
                    caffeine.Pop();
                    drinks.Enqueue(drinks.Dequeue());
                    if (currentCaffeineIntake < 30)
                    {
                        currentCaffeineIntake = 0;
                    }
                    else
                    {
                        currentCaffeineIntake -= 30;
                    }

                }
            }


            if (drinks.Any())
            {
                Console.WriteLine($"Drinks left: {String.Join(", ", drinks)}"); ;
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine($"Stamat is going to sleep with {currentCaffeineIntake} mg caffeine.");
        }
    }
}
