using System;

namespace _07._Concat_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string delimiter = Console.ReadLine();
            string output = firstName + delimiter + lastName;
            Console.WriteLine(output);
        }
    }
}
