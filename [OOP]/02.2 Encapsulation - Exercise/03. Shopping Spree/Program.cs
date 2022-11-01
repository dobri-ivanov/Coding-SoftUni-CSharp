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
            try
            {
                people = ReadPeopleInfo();
                products = ReadProductsInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string personName = input.Split().First();
                string productName = input.Split().Last();
                Person currentPerson = people.Find(p => p.Name == personName);
                Product currentProduct = products.Find(p => p.Name == productName);
                if (currentPerson != null && currentProduct != null)
                    currentPerson.BuyProduct(currentProduct);
            }

            foreach (Person person in people)
            {
                if (person.Bag.Any())
                    Console.WriteLine(person.Name + " - " + String.Join(", ", person.Bag));
                else
                    Console.WriteLine($"{person.Name} - Nothing bought");
            }
        }

        private static List<Person> ReadPeopleInfo()
        {
            List<Person> people = new List<Person>();
            string[] info = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < info.Length; i++)
            {
                string name = info[i]
                    .Split('=', StringSplitOptions.RemoveEmptyEntries).First();
                decimal money = decimal.Parse(info[i]
                    .Split('=', StringSplitOptions.RemoveEmptyEntries).Last());
                people.Add(new Person(name, money));
            }
            return people;
        }

        private static List<Product> ReadProductsInfo()
        {
            List<Product> products = new List<Product>();
            string[] info = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < info.Length; i++)
            {
                string name = info[i]
                    .Split('=', StringSplitOptions.RemoveEmptyEntries).First();
                decimal cost = decimal.Parse(info[i]
                    .Split('=', StringSplitOptions.RemoveEmptyEntries).Last());
                products.Add(new Product(name, cost));
            }
            return products;
        }
    }
}
