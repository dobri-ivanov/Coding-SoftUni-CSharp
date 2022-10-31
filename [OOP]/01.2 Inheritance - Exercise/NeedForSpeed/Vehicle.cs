using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.FuelConsumption = DEFAULT_FUEL_CONSUMPTION; 
            Fuel = fuel;
            HorsePower = horsePower;
        }

        private const double DEFAULT_FUEL_CONSUMPTION = 1.25;
        public virtual double FuelConsumption { get; set; }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            double fuelToBeRemoved = Fuel - FuelConsumption * kilometers;
            if (fuelToBeRemoved >= 0)
            {
                this.Fuel = fuelToBeRemoved;
            }
        }
    }
}
