using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matix = new int[size[0], size[1]];

            int rows = size[0];
            int cols = size[1];
            int sum = 0;

            for (int i = 0; i < size[0]; i++)
            {
                int[] row = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < size[1]; j++)
                {
                    matix[i, j] = row[j];
                    sum += row[j];
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
