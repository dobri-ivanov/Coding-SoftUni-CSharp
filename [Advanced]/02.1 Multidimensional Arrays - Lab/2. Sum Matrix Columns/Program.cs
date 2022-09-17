using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            int[,] matix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matix[row, col] = rowInput[col];
                }
            }

            for (int col = 0; col < cols; col++)
            {
                int colSum = 0;
                for (int row = 0; row < rows; row++)
                {
                    colSum += matix[row, col];
                }
                Console.WriteLine(colSum);
            }
        }
    }
}
