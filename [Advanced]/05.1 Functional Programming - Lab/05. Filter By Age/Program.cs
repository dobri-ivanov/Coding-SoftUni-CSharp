using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> people = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                if (!people.ContainsKey(name))
                {
                    people.Add(name, age);
                }
                people[name] = age;
            }

            string condition = Console.ReadLine();
            int ageTreshHold = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            if (format == "name age")
            {
                if (condition == "older")
                {
                    var filtredPeople = people.Where(p => p.Value >= ageTreshHold);
                    foreach (var person in filtredPeople)
                    {
                        Console.WriteLine($"{person.Key} - {person.Value}");
                    }
                }
                else if (condition == "younger")
                {
                    var filtredPeople = people.Where(p => p.Value < ageTreshHold);
                    foreach (var person in filtredPeople)
                    {
                        Console.WriteLine($"{person.Key} - {person.Value}");
                    }
                }
            }
            else if (format == "name")
            {
                if (condition == "older")
                {
                    var filtredPeople = people.Where(p => p.Value >= ageTreshHold);
                    foreach (var person in filtredPeople)
                    {
                        Console.WriteLine($"{person.Key}");
                    }
                }
                else if (condition == "younger")
                {
                    var filtredPeople = people.Where(p => p.Value < ageTreshHold);
                    foreach (var person in filtredPeople)
                    {
                        Console.WriteLine($"{person.Key}");
                    }
                }
            }
            else if (format == "age")
            {
                if (condition == "older")
                {
                    var filtredPeople = people.Where(p => p.Value >= ageTreshHold);
                    foreach (var person in filtredPeople)
                    {
                        Console.WriteLine($"{person.Value}");
                    }
                }
                else if (condition == "younger")
                {
                    var filtredPeople = people.Where(p => p.Value < ageTreshHold);
                    foreach (var person in filtredPeople)
                    {
                        Console.WriteLine($"{person.Value}");
                    }
                }
            }
        }
    }
}
