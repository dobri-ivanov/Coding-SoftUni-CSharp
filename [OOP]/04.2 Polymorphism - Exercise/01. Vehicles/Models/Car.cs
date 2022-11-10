using System;
using System.Collections.Generic;
using System.Text;
using _01._Vehicles.Models.Interfaces;

namespace _01._Vehicles.Models
{
    public class Car : IDrivable
    {
        public Car(double fuelQuantitiy, double fuelConsumptionPerKilometer, double tankCapacity)
        {
            FuelQuantitiy = fuelQuantitiy;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer + 0.9;
            TankCapacity = tankCapacity;
        }

        public double FuelQuantitiy { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TankCapacity { get; set; }

        public string Drive(double kilometers)
        {
            if (FuelQuantitiy >= kilometers * FuelConsumptionPerKilometer)
            {
                FuelQuantitiy -= kilometers * FuelConsumptionPerKilometer;
                return $"Car travelled {kilometers} km";
            }
            return "Car needs refueling";
        }

        public string Refuel(double fuel)
        {

            if (fuel + FuelQuantitiy > TankCapacity)
            {
                return $"Cannot fit {fuel} fuel in the tank";
            }
            FuelQuantitiy += fuel;
            return null;
        }

        public override string ToString()
        {
            return $"Car: {FuelQuantitiy:f2}";
        }
    }
}
