using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> storage = new Dictionary<string, int>();
            string line = Console.ReadLine();
            while (line != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());
                if (!storage.ContainsKey(line))
                {
                    storage.Add(line, 0);
                }
                storage[line] += quantity;
                line = Console.ReadLine();
            }

            foreach (var element in storage)
            {
                Console.WriteLine(element.Key + " -> " + element.Value);
            }
        }
    }
}
