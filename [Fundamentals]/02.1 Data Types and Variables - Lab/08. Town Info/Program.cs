using System;

namespace _08._Town_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            long population = long.Parse(Console.ReadLine());
            int area = int.Parse(Console.ReadLine());

            string output = String.Format($"Town {town} has population of {population} and area {area} square km.");
            Console.WriteLine(output);
        }
    }
}
