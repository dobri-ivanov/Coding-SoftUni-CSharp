using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            DefaultFuelConsumption = 1.25;
            Fuel = fuel;
            HorsePower = horsePower;
        }

        public double DefaultFuelConsumption { get; set; }
        public virtual double FuelConsumption { get; set; }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            double fuelToBeRemoved = kilometers / 100 * this.DefaultFuelConsumption;
            this.Fuel -= fuelToBeRemoved;
        }
    }
}
