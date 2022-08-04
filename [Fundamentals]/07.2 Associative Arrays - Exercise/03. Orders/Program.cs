using System;
using System.Collections.Generic;

namespace _03._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> pricesOfProducts = new Dictionary<string, double>();
            Dictionary<string, int> quantitiesOfProducts = new Dictionary<string, int>();

            string line = Console.ReadLine();
            while (line != "buy")
            {
                string[] tokens = line.Split(" ");
                string product = tokens[0];
                double price = double.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);

                if (!pricesOfProducts.ContainsKey(product))
                {
                    pricesOfProducts.Add(product, price);
                    quantitiesOfProducts.Add(product, quantity);
                }
                else
                {
                    if (pricesOfProducts[product] != price)
                    {
                        pricesOfProducts[product] = price;
                    }
                    quantitiesOfProducts[product] += quantity;
                }

                line = Console.ReadLine();
            }
            foreach (var item in pricesOfProducts)
            {
                string product = item.Key;
                int quantity = quantitiesOfProducts[product];
                double price = item.Value;
                Console.WriteLine($"{product} -> {(quantity * price):f2}");
            }
        }
    }
}
