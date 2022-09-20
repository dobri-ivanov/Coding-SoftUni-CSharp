using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "END")
                {
                    break;
                }
                if (input[0] == "swap")
                {
                    if (IsValidCoords(dimensions, input))
                    {
                        int row1 = int.Parse(input[1]);
                        int col1 = int.Parse(input[2]);
                        int row2 = int.Parse(input[3]);
                        int col2 = int.Parse(input[4]);

                        string memory = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = memory;

                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

            }
        }
        static bool IsValidCoords(int[] dimentions, string[] input)
        {
            int rows = dimentions[0];
            int cols = dimentions[1];
            bool isValid = false;

            if (input.Length == 5)
            {
                int row1 = int.Parse(input[1]);
                int col1 = int.Parse(input[2]);
                int row2 = int.Parse(input[3]);
                int col2 = int.Parse(input[4]);

                isValid = (row1 >= 0 && row1 < rows &&
                            col1 >= 0 && col1 < cols &&
                            row2 >= 0 && row2 < cols &&
                            col2 >= 0 && col2 < cols);
            }
            
            return isValid;
        }
    }
}
