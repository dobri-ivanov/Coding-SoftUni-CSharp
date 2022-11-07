using _04.BorderControl.Model;
using _04.BorderControl.Model.Interfaces;
using _04.BorderControl.Models;
using _04.BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int totalFood = 0;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 4)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    string birthdate = tokens[3];
                    IBuyer currentCitizen = new Citizen(name, age, id, birthdate);
                    buyers.Add(currentCitizen);
                }
                else if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string group = tokens[2];
                    IBuyer rebel = new Rebel(name, age, group);
                    buyers.Add(rebel);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;

                }
                string[] tokens = input.Split();
                if (tokens.Length == 1)
                {
                    string name = tokens[0]; ;
                    if (buyers.Any(x => x.Name == name))
                    {
                        IBuyer buyer = buyers.Find(x => x.Name == name);
                        totalFood += buyer.BuyFood();
                    }
                }
            }
            Console.WriteLine(totalFood);


        }
    }
}
