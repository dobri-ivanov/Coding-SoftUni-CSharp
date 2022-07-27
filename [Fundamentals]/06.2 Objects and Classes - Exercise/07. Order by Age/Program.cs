using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    public class Orders
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Orders> ordersByPerson = new List<Orders>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }
                string[] index = line.Split();
                Orders orders = new Orders
                {
                    Name = index[0],
                    ID = int.Parse(index[1]),
                    Age = int.Parse(index[2])
                };
                ordersByPerson.Add(orders);
            }
            List<Orders> peopleOrders = ordersByPerson
             .OrderBy(x => x.Age)
             .ToList();
            foreach (var orders in peopleOrders)
            {
                Console.WriteLine(orders);
            }
        }
    }
}
