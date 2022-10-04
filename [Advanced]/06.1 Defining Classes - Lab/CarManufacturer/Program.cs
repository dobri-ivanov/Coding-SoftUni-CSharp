using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tiresList = new List<Tire[]>();
            List<Engine> enginesList = new List<Engine>();
            List<Car> cars = new List<Car>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "No more tires")
                {
                    break;
                }
                double[] tires = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                int indexInput = 0;
                Tire[] tiresInput = new Tire[4];

                for (int i = 0; i < 4; i++)
                {
                    int year = int.Parse(tires[indexInput++].ToString());
                    double pressire = tires[indexInput++];
                    Tire newTire = new Tire(year, pressire);
                    tiresInput[i] = newTire;
                }
                tiresList.Add(tiresInput);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Engines done")
                {
                    break;
                }
                string[] engines = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(engines[0]);
                double cubicCapacity = double.Parse(engines[1]);
                Engine newEngine = new Engine(horsePower, cubicCapacity);
                enginesList.Add(newEngine);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Show special")
                {
                    break;
                }
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                int fuelQuantity = int.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                Car newCar = new Car(make, model, year, fuelQuantity, fuelConsumption, enginesList[engineIndex], tiresList[tiresIndex]);
                cars.Add(newCar);
            }

            foreach (var car in cars)
            {
                if (car.Year >= 2017 && car.Engine.HorsePower > 330)
                {
                    double tireSum = 0;
                    foreach (var tire in car.Tires)
                    {
                        tireSum += tire.Pressure;
                    }
                    if (tireSum > 9 && tireSum < 10)
                    {
                        car.Drive(0.20);
                        Console.WriteLine(car.WhoAmI());
                    }
                }
            }
        }
    }
}
