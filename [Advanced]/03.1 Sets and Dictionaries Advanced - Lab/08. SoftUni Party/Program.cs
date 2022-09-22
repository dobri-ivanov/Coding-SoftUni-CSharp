using System;
using System.Collections.Generic;

namespace _08._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();


            string input = Console.ReadLine();
            while (true)
            {
                if (input == "PARTY")
                {
                    break;
                }

                if (char.IsDigit(input[0]))
                {
                    vipGuests.Add(input);
                }
                else
                {
                    regularGuests.Add(input);
                }
                input = Console.ReadLine();
            }
            while (input != "END")
            {
                vipGuests.Remove(input);
                regularGuests.Remove(input);

                input = Console.ReadLine();
            }

            Console.WriteLine(vipGuests.Count + regularGuests.Count);

            if (vipGuests.Count > 0)
            {
                foreach (var guest in vipGuests)
                {
                    Console.WriteLine(guest);
                }
            }

            if (regularGuests.Count > 0)
            {
                foreach (var guest in regularGuests)
                {
                    Console.WriteLine(guest);
                }
            }
        }
    }
}
