using System;
using System.Collections.Generic;

namespace _08.CarSalesman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Engine> enginesByNames = new Dictionary<string, Engine>();
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                int power = int.Parse(tokens[1]);
                Engine engine = new Engine { Model = model, Power = power, Displacement = 0, Efficiency = "n/a" };
                if (tokens.Length > 2)
                {
                    int memory = 0;
                    bool success = int.TryParse(tokens[2], out memory);
                    if (!success)
                    {
                        engine.Efficiency = tokens[2];
                    }
                    else
                    {
                        int engineDisplacement = int.Parse(tokens[2]);
                        engine.Displacement = engineDisplacement;
                    }

                    if (tokens.Length > 3)
                    {
                        string engineEfficiency = tokens[3];
                        engine.Efficiency = engineEfficiency;
                    }
                }
                enginesByNames.Add(model, engine);
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                string engineModel = tokens[1];
                Engine currentEngine = enginesByNames[engineModel];
                Car car = new Car { Model = model, Engine = currentEngine, Weight = 0, Colour = "n/a" };

                if (tokens.Length > 2)
                {
                    int memory;
                    bool success = int.TryParse(tokens[2], out memory);
                    if (!success)
                    {
                        car.Colour = tokens[2];
                    }
                    else
                    {
                        int weight = int.Parse(tokens[2]);
                        car.Weight = weight;
                    }

                    if (tokens.Length > 3)
                    {
                        string colour = tokens[3];
                        car.Colour = colour;
                    }
                }
                cars.Add(car);

            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.Model + ":");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                if (car.Engine.Displacement > 0)
                {
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                }
                else
                {
                    Console.WriteLine($"    Displacement: n/a");
                }
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                if (car.Weight > 0)
                {
                    Console.WriteLine($"  Weight: {car.Weight}");
                }
                else
                {
                    Console.WriteLine($"  Weight: n/a");
                }
                Console.WriteLine($"  Color: {car.Colour}");

            }
        }
    }
}
