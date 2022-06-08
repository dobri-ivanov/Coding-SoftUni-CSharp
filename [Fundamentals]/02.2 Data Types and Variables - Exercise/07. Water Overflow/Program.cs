using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int capacity = 255;

            for (int i = 0; i < n; i++)
            {
                int water = int.Parse(Console.ReadLine());
                if (capacity >= water)
                {
                    capacity -= water;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
            }
            Console.WriteLine(255 - capacity);
        }
    }
}
