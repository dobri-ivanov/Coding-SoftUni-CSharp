using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();
            while (true)
            {
                string[] tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "END")
                {
                    break;
                }
                string command = tokens[0];
                string licensePlate = tokens[1];

                if (command == "IN")
                {
                    parkingLot.Add(licensePlate);
                }
                else if (command == "OUT")
                {
                    if (parkingLot.Contains(licensePlate))
                    {
                        parkingLot.Remove(licensePlate);
                    }
                }
            }

            if (parkingLot.Count > 0)
            {
                foreach (var licensePlate in parkingLot)
                {
                    Console.WriteLine(licensePlate);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
