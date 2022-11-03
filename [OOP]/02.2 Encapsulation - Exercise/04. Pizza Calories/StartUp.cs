using System;
using System.Linq;

namespace _04._Pizza_Calories
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string pizzaInput = Console.ReadLine();
            string pizzaName = pizzaInput.Split(" ", StringSplitOptions.RemoveEmptyEntries).Last();

            string[] doughtInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string doughtType = doughtInput[1];
            string doughtBakingTechnique = doughtInput[2];
            double doughtGrams = double.Parse(doughtInput[3]);

            try
            {
                Dought dought = new Dought(doughtType, doughtBakingTechnique, doughtGrams);
                Pizza pizza = new Pizza(pizzaName, dought);

                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "END")
                    {
                        break;
                    }
                    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string toppingType = tokens[1];
                    double toppingGrams = double.Parse(tokens[2]);
                    Topping topping = new Topping(toppingType, toppingGrams);
                    pizza.AddTopping(topping);
                }
                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
