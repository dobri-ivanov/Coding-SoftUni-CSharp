using System;
using System.Linq;

namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int steps = int.Parse(Console.ReadLine());

            for (int i = 0; i < steps; i++)
            {
                int memory = array[0];
                for (int j = 0; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];
                }
                array[array.Length - 1] = memory;
            }

            Console.WriteLine(String.Join(" ", array));
        }
    }
}
