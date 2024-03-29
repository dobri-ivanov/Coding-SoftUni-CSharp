﻿using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = GetMatrixInputData(size);
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split();
                string command = tokens[0];
                int rowIndex = int.Parse(tokens[1]);
                int colIndex = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if (IndexIsValid(rowIndex, size) && IndexIsValid(colIndex, size))
                {
                    if (command == "Add")
                        matrix[rowIndex, colIndex] += value;
                    else if (command == "Subtract")
                        matrix[rowIndex, colIndex] -= value;
                }
                else
                    Console.WriteLine("Invalid coordinates");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static int[,] GetMatrixInputData(int size)
        {
            int[,] matrix = new int[size, size];
            for (int row = 0; row < size; row++)
            {
                int[] inputLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = inputLine[col];
                }
            }
            return matrix;
        }

        static bool IndexIsValid(int index, int size)
            => index < size && index >= 0;
    }
}
