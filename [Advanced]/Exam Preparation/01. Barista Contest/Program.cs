using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace _01._Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] coffeeInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] milkInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Dictionary<string, int> drinks = new Dictionary<string, int>();
            Dictionary<string, int> collectionOfDrinks = new Dictionary<string, int>();
            drinks.Add("Cortado", 50);
            drinks.Add("Espresso", 75);
            drinks.Add("Capuccino", 100);
            drinks.Add("Americano", 150);
            drinks.Add("Latte", 200);
            
            Queue<int> coffee = new Queue<int>();
            Stack<int> milk = new Stack<int>();

            for (int i = 0; i < coffeeInput.Length; i++)
            {
                coffee.Enqueue(coffeeInput[i]);
            }
            for (int i = 0; i < milkInput.Length; i++)
            {
                milk.Push(milkInput[i]);
            }

            while (true)
            {
                if (milk.Count == 0 || coffee.Count == 0)
                {
                    break;
                }

                int currentQuantity = coffee.Peek() + milk.Peek();

                bool hasFound = false;
                foreach (var drink in drinks)
                {
                    if (drink.Value == currentQuantity)
                    {
                        if (!collectionOfDrinks.ContainsKey(drink.Key))
                        {
                            collectionOfDrinks.Add(drink.Key, 0);
                        }
                        if (coffee.Any())
                        {
                            coffee.Dequeue();
                        }
                        if (milk.Any())
                        {
                            milk.Pop();
                        }
                        collectionOfDrinks[drink.Key]++;
                        hasFound = true;
                        break;
                    }
                }
                if (!hasFound)
                {
                    if (coffee.Any())
                    {
                        coffee.Dequeue();
                    }
                    milk.Push(milk.Pop() - 5);
                }  
            }

            if (!milk.Any() && !coffee.Any())
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else if (milk.Any() || coffee.Any())
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (!coffee.Any())
            {
                Console.WriteLine($"Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {String.Join(", ", coffee)}");
            }

            if (!milk.Any())
            {
                Console.WriteLine($"Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {String.Join(", ", milk)}");
            }

            collectionOfDrinks = collectionOfDrinks.OrderBy(x => x.Value).ThenByDescending(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var drink in collectionOfDrinks)
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        }
    }
}
