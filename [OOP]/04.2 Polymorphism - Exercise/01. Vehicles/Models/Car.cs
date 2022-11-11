using System;
using System.Collections.Generic;
using System.Text;
using _01._Vehicles.Models.Interfaces;

namespace _01._Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + 0.9, tankCapacity)
        {
        }
    }
}
