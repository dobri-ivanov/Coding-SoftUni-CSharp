using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace _07.RawData
{
    public class Car
    {

		private string model;
		private Engine engine;
		private Cargo cargo;
		private Tire[] tires;

		public string Model { get; set; }
		public Engine Engine { get; set; }
		public Cargo Cargo { get; set; }
		public Tire[] Tires { get; set; }

		public Car(string model, int engineSpeed , int enginePower, int cargoWeight, string cargoType, 
			int tire1Age,
			float tire1Pressure,
            int tire2Age,
            float tire2Pressure,
            int tire3Age,
            float tire3Pressure,
            int tire4Age,
            float tire4Pressure)

        {
			this.Model = model;
			this.Engine = new Engine { Speed = engineSpeed, Power = enginePower};
			this.Cargo = new Cargo { Weight = cargoWeight, Type = cargoType};
			this.Tires = new Tire[4];
			Tires[0] = new Tire { Age = tire1Age, Pressure = tire1Pressure};
			Tires[1] = new Tire { Age = tire2Age, Pressure = tire2Pressure};
			Tires[2] = new Tire { Age = tire3Age, Pressure = tire3Pressure};
			Tires[3] = new Tire { Age = tire4Age, Pressure = tire4Pressure};

		}

		public bool CheckCar(string cargoType)
		{
			if (cargoType == "fragile")
			{
				bool isValidType = false;
				bool hasValidTires = false;

				if (this.Cargo.Type == cargoType)
				{ 
					isValidType = true;
				}

				foreach (var tire in this.Tires)
				{
					if (tire.Pressure < 1)
					{
						hasValidTires = true;
						break;
					}
				}

				if (isValidType && hasValidTires)
				{
					return true;
				}
			}
			else if (cargoType == "flammable")
			{
                bool isValidType = false;
                bool hasValidEnginePower = false;

                if (this.Cargo.Type == cargoType)
                {
                    isValidType = true;
                }
				if (this.Engine.Power > 250)
				{
					hasValidEnginePower = true;
				}
				if (isValidType && hasValidEnginePower)
				{
					return true;
				}
            }
			return false;
		}
	}
}
