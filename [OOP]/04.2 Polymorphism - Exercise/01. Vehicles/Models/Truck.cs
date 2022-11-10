using System;
using System.Collections.Generic;
using System.Text;
using _01._Vehicles.Models.Interfaces;

namespace _01._Vehicles.Models
{
    internal class Truck : IDrivable
    {
        public Truck(double fuelQuantitiy, double fuelConsumptionPerKilometer, double tankCapacity)
        {
            FuelQuantitiy = fuelQuantitiy;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer + 1.6;
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
                return $"Truck travelled {kilometers} km";
            }
            return "Truck needs refueling";
        }

        public string Refuel(double fuel)
        {
            double fuelToBeFilled = fuel * 0.95;
            if (fuelToBeFilled + FuelQuantitiy > TankCapacity)
            {
                return $"Cannot fit {fuel} fuel in the tank";
            }
            FuelQuantitiy += fuelToBeFilled;
        }

        public override string ToString()
        {
            return $"Truck: {FuelQuantitiy:f2}";
        }
    }
}
