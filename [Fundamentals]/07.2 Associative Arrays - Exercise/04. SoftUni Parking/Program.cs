using System;
using System.Collections.Generic;

namespace _04._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parking = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];
                string user = tokens[1];
                switch (command)
                {
                    case "register":
                        string licensePlate = tokens[2];
                        if (!parking.ContainsKey(user))
                        {
                            parking.Add(user, licensePlate);
                            Console.WriteLine($"{user} registered {licensePlate} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                        }
                        break;
                    case "unregister":
                        if (parking.ContainsKey(user))
                        {
                            parking.Remove(user);
                            Console.WriteLine($"{user} unregistered successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: user {user} not found");
                        }

                        break;
                    default:
                        break;
                }
  
            }
            foreach (var slots in parking)
            {
                Console.WriteLine($"{slots.Key} => {slots.Value}");
            }
        }
    }
}
