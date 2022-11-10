using _01._Vehicles.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Vehicles.Models
{
    public class Bus : IDrivable
    {
        public Bus(double fuelQuantitiy, double fuelConsumptionPerKilometer, double tankCapacity)
        {
            FuelQuantitiy = fuelQuantitiy;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TankCapacity = tankCapacity;
        }

        public double FuelQuantitiy { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TankCapacity { get; set; }

        public string Drive(double kilometers)
        {
            if(FuelQuantitiy >= kilometers * FuelConsumptionPerKilometer)
            {
                FuelQuantitiy -= kilometers * FuelConsumptionPerKilometer;
                return $"Bus travelled {kilometers} km";
            }
            return "Bus needs refueling";
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

    }
}
