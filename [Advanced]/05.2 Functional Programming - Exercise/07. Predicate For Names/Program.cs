using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Predicate<string> isValid = name => name.Length <= length;

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in names)
            {
                if (isValid(name))
                {
                    Console.WriteLine(name);
                }
            }

        }
    }
}
