using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matix = new int[size, size];
            int rows = size;
            int cols = size;
            int diagonalSum = 0;

            for (int row = 0; row < rows; row++)
            {
                int[] rowInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matix[row, col] = rowInput[col];
                    if (row == col)
                    {
                        diagonalSum += rowInput[col];
                    }
                }
            }

            Console.WriteLine(diagonalSum);
        }
    }
}
