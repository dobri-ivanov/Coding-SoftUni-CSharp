using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;

namespace _02._Beaver_at_Work
{
    internal class Program
    {
        public static char[,] matrix;
        public static string currentCommand;
        public static int braverRow;
        public static int braverCol;
        public static Stack<char> collectedBranches;
        public static int countOfBranches;

        public static int n;
        static void Main(string[] args)
        {
            collectedBranches = new Stack<char>();
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
                        braverRow = i;
                        braverCol = j;
                    }
                    else if (char.IsLower(rowInput[j]) && rowInput[j] != '-')
                    {
                        countOfBranches++;
                    }
                }
            }
            while (true)
            {
                bool hasFinished = false;
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                currentCommand = input;
                if (currentCommand == "up")
                {
                    hasFinished = Move(-1, 0);
                }
                else if (currentCommand == "down")
                {
                    hasFinished = Move(1, 0);
                }
                else if (currentCommand == "left")
                {
                    hasFinished = Move(0, -1);
                }
                else if (currentCommand == "right")
                {
                    hasFinished = Move(0, 1);

                }
                if (hasFinished)
                {
                    Console.WriteLine($"The Beaver successfully collect {collectedBranches.Count} wood branches: {String.Join(", ", collectedBranches)}.");
                    PrintMatrix();
                    return;
                }
            }
            Console.WriteLine($"The Beaver failed to collect every wood branch. There are {countOfBranches} branches left.");
            PrintMatrix();
        }

        private static bool Move(int rowValue, int colValue)
        {
            int currentRowIndex = braverRow + rowValue;
            int currentColIndex = braverCol + colValue;

            if (AreValidIndexes(currentRowIndex, currentColIndex))
            {
                char symbol = matrix[currentRowIndex, currentColIndex];
                if (symbol == '-')
                {
                    matrix[braverRow, braverCol] = '-';
                    matrix[currentRowIndex, currentColIndex] = 'B';
                    braverRow = currentRowIndex;
                    braverCol = currentColIndex;
                }
                else if (char.IsLower(symbol) && symbol != '-')
                {
                    matrix[braverRow, braverCol] = '-';
                    matrix[currentRowIndex, currentColIndex] = 'B';
                    braverRow = currentRowIndex;
                    braverCol = currentColIndex;
                    collectedBranches.Push(symbol);
                    countOfBranches--;
                    if (countOfBranches == 0)
                    {
                        Console.WriteLine();
                        return true;
                    }
                }
                else if (symbol == 'F')
                {
                    matrix[braverRow, braverCol] = '-';
                    matrix[currentRowIndex, currentColIndex] = 'B';
                    braverRow = currentRowIndex;
                    braverCol = currentColIndex;
                    EatFish();
                }
            }
            else
            {
                collectedBranches.Pop();
            }
            return false;
        }

        private static void EatFish()
        {
            if (currentCommand == "up")
            {
                if (braverRow != 0)
                {
                    Move(-braverRow, 0);
                }
                else
                {
                    Move(n - 1 - braverRow, 0);
                }
            }
            else if (currentCommand == "down")
            {
                if (braverRow != n - 1)
                {
                    Move(n - 1 - braverRow, 0);
                }
                else
                {
                    Move(-braverRow, 0);
                }
            }
            else if (currentCommand == "left")
            {
                if (braverCol != 0)
                {
                    Move(0, -braverRow);
                }
                else
                {
                    Move(0, n - 1 - braverCol);
                }
            }
            else if (currentCommand == "right")
            {
                if (braverCol != n - 1)
                {
                    Move(0, n - 1 - braverCol);
                }
                else
                {
                    Move(0, -braverCol);
                }
            }
        }

        private static bool AreValidIndexes(int currentRowIndex, int currentColIndex)
        {
            if (currentRowIndex >= 0 && currentRowIndex < matrix.GetLength(0) &&
                currentColIndex >= 0 && currentColIndex < matrix.GetLength(1))
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
