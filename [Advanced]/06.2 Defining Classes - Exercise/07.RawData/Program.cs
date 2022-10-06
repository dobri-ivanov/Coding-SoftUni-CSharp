using System;
using System.Collections.Generic;

namespace _07.RawData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);
                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];

                float tire1Pressure = float.Parse(tokens[5]);
                int tire1Age = int.Parse(tokens[6]);
                float tire2Pressure = float.Parse(tokens[7]);
                int tire2Age = int.Parse(tokens[8]);
                float tire3Pressure = float.Parse(tokens[9]);
                int tire3Age = int.Parse(tokens[10]);
                float tire4Pressure = float.Parse(tokens[11]);
                int tire4Age = int.Parse(tokens[12]);

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tire1Age, tire1Pressure, tire2Age, tire2Pressure,
                    tire3Age, tire3Pressure, tire4Age, tire4Pressure);
                cars.Add(car);
            }

            string cargoTypeSearch = Console.ReadLine();
            foreach (var currentCar in cars)
            {
                if (currentCar.CheckCar(cargoTypeSearch))
                {
                    Console.WriteLine(currentCar.Model);
                }
            }
        }
    }
}
