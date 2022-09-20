using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[n][];

            for (int row = 0; row < n; row++)
            {
                int[] rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jaggedArray[row] = rowInput;
            }

            for (int row = 0; row < n - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }
                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "End")
                {
                    break;
                }
                else if (tokens[0] == "Add")
                {
                    if (IsValidCoords(tokens, jaggedArray))
                    {
                        int row = int.Parse(tokens[1]);
                        int col = int.Parse(tokens[2]);
                        int value = int.Parse(tokens[3]);

                        jaggedArray[row][col] += value;
                    }
                }
                else if (tokens[0] == "Subtract")
                {
                    if (IsValidCoords(tokens, jaggedArray))
                    {
                        int row = int.Parse(tokens[1]);
                        int col = int.Parse(tokens[2]);
                        int value = int.Parse(tokens[3]);

                        jaggedArray[row][col] -= value;
                    }
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsValidCoords(string[] tokens, int[][] jaggedArray)
        {
            int row = int.Parse(tokens[1]);
            int col = int.Parse(tokens[2]);
            bool isValid = false;

            if (tokens.Length == 4)
            {
                if (row >= 0 && row < jaggedArray.Length)
                {
                    if (col >= 0 && col < jaggedArray[row].Length)
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }
    }
}
