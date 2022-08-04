using System;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> storage = new Dictionary<char, int>();
            string line = Console.ReadLine();

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != ' ')
                {
                    if (!storage.ContainsKey(line[i]))
                    {
                        storage.Add(line[i], 0);
                    }
                    storage[line[i]]++;
                }
            }

            foreach (var element in storage)
            {
                Console.WriteLine(element.Key + " -> " + element.Value);
            }
        }
    }
}
