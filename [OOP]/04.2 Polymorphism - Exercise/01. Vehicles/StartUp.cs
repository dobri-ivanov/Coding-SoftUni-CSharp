using _01._Vehicles.Models;
using _01._Vehicles.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace _01._Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IDrivable> vehicles = new List<IDrivable>();

            string[] carTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            double carFuelQuantity = double.Parse(carTokens[0]);
            double carFuelConsumptionPerKilometer = double.Parse(carTokens[1]);
            double carTankCapacity = double.Parse(carTokens[2]);
            IDrivable car = new Car(carFuelQuantity, carFuelConsumptionPerKilometer, carTankCapacity);
            vehicles.Add(car);

            string[] truckTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            double truckFuelQuantity = double.Parse(truckTokens[0]);
            double truckFuelConsumptionPerKilometer = double.Parse(truckTokens[1]);
            double truckTankCapacity = double.Parse(truckTokens[2]);
            IDrivable truck = new Truck(truckFuelQuantity, truckFuelConsumptionPerKilometer, truckTankCapacity);
            vehicles.Add(truck);

            string[] busTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            double busFuelQuantity = double.Parse(busTokens[0]);
            double busFuelConsumptionPerKilometer = double.Parse(busTokens[1]);
            double busTankCapacity = double.Parse(busTokens[2]);
            IDrivable bus = new Bus(busFuelQuantity, busFuelConsumptionPerKilometer, busTankCapacity);
            vehicles.Add(bus);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string typeOfVehicle = tokens[1];
                double value = double.Parse(tokens[2]);

                int index = 0;
                if (typeOfVehicle == "Truck")
                {
                    index = 1;
                }
                else if (typeOfVehicle == "Bus")
                {
                    index = 3;
                }

                if (command == "Drive")
                {
                    string output = vehicles[index].Drive(value);
                    Console.WriteLine(output);
                }
                else if (command == "Refuel")
                {
                    string output = vehicles[index].Refuel(value);
                    if (output != null) Console.WriteLine(output);
                }
            }

            vehicles.ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
}
