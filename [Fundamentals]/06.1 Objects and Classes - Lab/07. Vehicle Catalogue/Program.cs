using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();
            catalog.Cars = new List<Car>();
            catalog.Trucks = new List<Truck>();

            while (true)
            {
                string[] input = Console.ReadLine().Split('/');
                if (input[0] == "Car")
                {
                    string brand = input[1];
                    string model = input[2];
                    int horsePower = int.Parse(input[3]);
                    Car car = new Car
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = horsePower
                    };
                    catalog.Cars.Add(car);
                }
                else if (input[0] == "Truck")
                {
                    string brand = input[1];
                    string model = input[2];
                    string weight = input[3];

                    Truck truck = new Truck
                    {
                        Brand = brand,
                        Model = model,
                        Weight = weight
                    };
                    catalog.Trucks.Add(truck);
                }
                else
                {
                    break;
                }
            }
            PrintCatalog(catalog);
        }

        static void PrintCatalog(Catalog catalog)
        {
            if (catalog.Cars.Count > 0)
            {
                List<Car> orderedCars = catalog.Cars.OrderBy(c => c.Brand).ToList();
                Console.WriteLine("Cars:");
                foreach (var car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (catalog.Trucks.Count > 0)
            {
                List<Truck> orderedTrucks = catalog.Trucks.OrderBy(t => t.Brand).ToList();
                Console.WriteLine("Trucks:");
                foreach (var truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }

        }
    }
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

    }
    class Catalog
    {
        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set; }
    }
}
