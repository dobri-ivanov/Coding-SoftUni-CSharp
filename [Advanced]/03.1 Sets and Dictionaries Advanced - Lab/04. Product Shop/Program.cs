using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopProducts = new Dictionary<string, Dictionary<string, double>>();
            while (true)
            {
                string[] tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Revision")
                {
                    break;
                }

                string shopName = tokens[0];
                string productName = tokens[1];
                double productPrice = double.Parse(tokens[2]);

                if (!shopProducts.ContainsKey(shopName))
                {
                    shopProducts[shopName] = new Dictionary<string, double>();
                }

                shopProducts[shopName][productName] = productPrice;
            }

            shopProducts = shopProducts.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var shop in shopProducts)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shopProducts[shop.Key])
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
