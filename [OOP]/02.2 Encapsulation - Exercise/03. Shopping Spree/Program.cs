using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03._Shopping_Spree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            string[] names = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < names.Length; i++)
            {
                string[] currentNameValues = names[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = currentNameValues[0];
                double money = double.Parse(currentNameValues[1]);

                try
                {
                    Person person = new Person(name, money);
                    people.Add(person);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            for (int i = 0; i < productsInput.Length; i++)
            {
                string[] currentProductValues = productsInput[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                string productName = currentProductValues[0];
                double productCost = double.Parse(currentProductValues[1]);

                try
                {
                    Product product = new Product(productName, productCost);
                    products.Add(product);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currentPersonName = tokens[0];
                string currentProductName = tokens[1];
                if (people.Any(x => x.Name == currentPersonName) && products.Any(x => x.Name == currentProductName))
                {
                    Person person = people.Find(x => x.Name == currentPersonName);
                    Product product = products.Find(x => x.Name == currentProductName);
                    bool success = person.BuyProduct(product);
                    if (!success)
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                    }
                }
            }

            people.ForEach(i => Console.WriteLine(i.ToString()));
        }
    }
}
