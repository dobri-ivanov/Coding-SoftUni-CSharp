using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Beaver_at_Work
{
    internal class Program
    {
        public static char[,] matrix;
        public static string currentCommand;
        public static int beaverRow;
        public static int beaverCol;
        public static List<char> collectedBranches;
        public static int countOfcollectedBranches;

        public static int n;
        static void Main(string[] args)
        {
            collectedBranches = new List<char>();
            n = int.Parse(Console.ReadLine());
            matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                char[] rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray(); ;
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rowInput[j];
                    if (rowInput[j] == 'B')
                    {
                        beaverRow = i;
                        beaverCol = j;
                    }
                    else if (char.IsLower(rowInput[j]) && rowInput[j] != '-')
                    {
                        countOfcollectedBranches++;
                    }
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                currentCommand = input;
                if (input == "up")
                {
                    Move(-1, 0);
                }
                else if (input == "down")
                {
                    Move(1, 0);
                }
                else if (input == "left")
                {
                    Move(0, -1);
                }
                else if (input == "right")
                {
                    Move(0, 1);
                }

                if (countOfcollectedBranches == 0)
                {
                    Console.WriteLine($"The Beaver successfully collect {collectedBranches.Count} wood branches: {String.Join(", ", collectedBranches)}.");
                    break;
                }
            }

            if (countOfcollectedBranches > 0)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {countOfcollectedBranches} branches left.");
            }
            PrintMatrix();
        }

        private static void Move(int rowValue, int colValue)
        {

            int currentRow = beaverRow + rowValue;
            int currentCol = beaverCol + colValue;

            if (AreValidCoords(currentRow, currentCol))
            {
                char symbol = matrix[currentRow, currentCol];
                if (char.IsLower(symbol))
                {
                    matrix[beaverRow, beaverCol] = '-';
                    matrix[currentRow, currentCol] = 'B';
                    beaverRow = currentRow;
                    beaverCol = currentCol;
                    collectedBranches.Add(symbol);
                    countOfcollectedBranches--;
                }
                else if (symbol == '-')
                {
                    matrix[beaverRow, beaverCol] = '-';
                    matrix[currentRow, currentCol] = 'B';
                    beaverRow = currentRow;
                    beaverCol = currentCol;
                }
                else if (symbol == 'F')
                {
                    matrix[beaverRow, beaverCol] = '-';
                    matrix[currentRow, currentCol] = '-';
                    beaverRow = currentRow;
                    beaverCol = currentCol;

                    int newRow = 0;
                    int newCol = 0;
                    if (currentCommand == "up")
                    {
                        if (beaverRow != 0)
                        {
                            newRow = 0;
                            newCol = beaverRow;
                        }
                        else
                        {
                            newRow = matrix.GetLength(0) - 1;
                            newCol = beaverCol;
                        }
                    }
                    else if (currentCommand == "down")
                    {
                        if (beaverRow != matrix.GetLength(0) - 1)
                        {
                            newRow = matrix.GetLength(0) - 1;
                            newCol = beaverCol;
                        }
                        else
                        {
                            newRow = 0;
                            newCol = beaverCol;
                        }
                    }
                    else if (currentCommand == "left")
                    {
                        if (beaverCol != 0)
                        {
                            newRow = beaverRow;
                            newCol = 0;
                        }
                        else
                        {
                            newRow = beaverRow;
                            newCol = matrix.GetLength(1) - 1;
                        }
                    }
                    else if (currentCommand == "right")
                    {
                        if (beaverCol != matrix.GetLength(1) - 1)
                        {
                            newRow = beaverRow;
                            newCol = matrix.GetLength(1) - 1;
                        }
                        else
                        {
                            newRow = beaverRow;
                            newCol = 0;
                        }
                    }

                    char newSymbol = matrix[newRow, newCol];
                    if (char.IsLower(newSymbol))
                    {
                        collectedBranches.Add(newSymbol);
                        countOfcollectedBranches--;
                    }
                    matrix[newRow, newCol] = 'B';
                    beaverRow = newRow;
                    beaverCol = newCol;

                }
            }
            else
            {
                if (collectedBranches.Any())
                {
                    collectedBranches.Remove(collectedBranches[collectedBranches.Count - 1]);
                }
            }
        }

        private static bool AreValidCoords(int currentRow, int currentCol)
        {
            if (currentRow >= 0 && currentRow < matrix.GetLength(0) && 
                currentCol >= 0 && currentCol < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }

        public static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
