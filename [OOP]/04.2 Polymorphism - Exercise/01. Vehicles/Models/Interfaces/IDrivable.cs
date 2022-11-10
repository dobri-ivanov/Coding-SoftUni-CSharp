using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Vehicles.Models.Interfaces
{
    public interface IDrivable
    {
        public double FuelQuantitiy { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TankCapacity { get; set; }
        public string Drive(double kilometers);
        public string Refuel(double fuel, double multiplayer = default == null);
    }
}
