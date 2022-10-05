﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _06.SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> carsByNames = new Dictionary<string, Car>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] carProps = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car
                {
                    Model = carProps[0],
                    FuelAmount = double.Parse(carProps[1]),
                    FuelConsumptionPerKilometer = double.Parse(carProps[2])
                };

                carsByNames.Add(car.Model, car);
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = tokens[1];
                double amountOfKilometers = double.Parse(tokens[2]);

                Car car = carsByNames[carModel];

                car.Drive(amountOfKilometers);
            }

            foreach (var car in carsByNames.Values)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }

    }
}
