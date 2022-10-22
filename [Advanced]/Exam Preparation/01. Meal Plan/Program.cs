using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace _01._Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> menu = new Dictionary<string, int>();
            menu.Add("salad", 350);
            menu.Add("soup", 490);
            menu.Add("pasta", 680);
            menu.Add("steak", 790);

            Stack<string> meals = new Stack<string>();
            Stack<int> caloriesPerDay = new Stack<int>();
            string[] mealsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < mealsInput.Length; i++)
            {
                meals.Push(mealsInput[i]);
            }

            int[] caloriesPerDayInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < caloriesPerDayInput.Length; i++)
            {
                caloriesPerDay.Push(caloriesPerDayInput[i]);
            }
            int countMeals = 0;

            while (true)
            {          
                string currentMeal = string.Empty;
                if (meals.Any())
                {
                    currentMeal = meals.Pop();
                    countMeals++;
                }
                int currentMealCalories = 0;
                foreach (var item in menu)
                {
                    if (currentMeal == item.Key)
                    {
                        currentMealCalories = item.Value;
                    }
                }
                int currentDailyCalories = 0;
                if (caloriesPerDay.Any())
                {
                    currentDailyCalories = caloriesPerDay.Peek();
                }
                
                if (currentDailyCalories > currentMealCalories)
                {
                    caloriesPerDay.Push(caloriesPerDay.Pop() - currentMealCalories);
                }
                else if (currentDailyCalories < currentMealCalories)
                {
                    int memory = currentMealCalories - currentDailyCalories;
                    if (caloriesPerDay.Any())
                    {
                        caloriesPerDay.Pop();
                    }
                    
                    if (caloriesPerDay.Any())
                    {
                        caloriesPerDay.Push(caloriesPerDay.Pop() - memory);
                    }
                   
                }
                else
                {
                    if (caloriesPerDay.Any())
                    {
                        caloriesPerDay.Pop();
                    }
                }

                if (!meals.Any())
                {
                    Console.WriteLine($"John had {countMeals} meals.");
                    Console.WriteLine($"For the next few days, he can eat {String.Join(", ", caloriesPerDay)} calories.");
                    return;
                }
                if (!caloriesPerDay.Any())
                {
                    Console.WriteLine($"John ate enough, he had {countMeals} meals.");
                    Console.WriteLine($"Meals left: {String.Join(", ", meals)}.");
                    return;
                }
                
            }
        }
    }
}
