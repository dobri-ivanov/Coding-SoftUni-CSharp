using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array1 = new int[n];
            int[] array2 = new int[n];

            int step = 1;
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                if (step % 2 == 0)
                {
                    array1[i] = input[1];
                    array2[i] = input[0];
                }
                else
                {
                    array1[i] = input[0];
                    array2[i] = input[1];
                }
                step++;
            }

            Console.WriteLine(String.Join(" ", array1));
            Console.WriteLine(String.Join(" ", array2));
        }
    }
}
