using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] array2 = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
                sum1 += array1[i];
                sum2 += array2[i];
            }
            Console.WriteLine($"Arrays are identical. Sum: {sum1}");
        }
    }
}
