using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int rows = n;
            int cols = n;

            int[,] matrix = new int[n, n];

            for (int row = 0; row < rows; row++)
            {
                int[] rowInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            int leftSum = 0;
            int rightSum = 0;

            for (int row = 0, col = cols - 1; row < rows; row++, col--)
            {
                leftSum += matrix[row, row];
                rightSum += matrix[col, row];
            }

            Console.WriteLine(Math.Abs(leftSum - rightSum));
        }
    }
}
