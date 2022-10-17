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
                bool isFinished = false;
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                currentCommand = input;
                if (input == "up")
                {
                    isFinished = Move(-1, 0);
                }
                else if (input == "down")
                {
                    isFinished = Move(1, 0);
                }
                else if (input == "left")
                {
                    isFinished = Move(0, -1);
                }
                else if (input == "right")
                {
                    isFinished = Move(0, 1);
                }

                if (isFinished)
                {
                    Console.WriteLine($"The Beaver successfully collect {collectedBranches.Count} wood collectedBranches: {String.Join(", ", collectedBranches)}.");
                    break;
                }
            }
            if (countOfcollectedBranches > 0)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {countOfcollectedBranches} collectedBranches left.");
            }
            PrintMatrix();
        }

        private static bool Move(int rowValue, int colValue)
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
                    matrix[beaverRow, beaverCol] = '-';

                    if (currentCommand == "up")
                    {
                        if (beaverRow == 0)
                        {
                            if (char.IsLower(matrix[matrix.GetLength(0) - 1, beaverCol]))
                            {
                                collectedBranches.Add(matrix[matrix.GetLength(0) - 1, beaverCol]);
                                countOfcollectedBranches--;
                            }
                            beaverRow = matrix.GetLength(0) - 1;
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                        else
                        {
                            if (char.IsLower(matrix[0, beaverCol]))
                            {
                                collectedBranches.Add(matrix[0, beaverCol]);
                                countOfcollectedBranches--;
                            }
                            beaverRow = 0;
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                    }
                    else if (currentCommand == "down")
                    {
                        if (beaverRow == matrix.GetLength(0) - 1)
                        {
                            if (char.IsLower(matrix[0, beaverCol]))
                            {
                                collectedBranches.Add(matrix[0, beaverCol]);
                                countOfcollectedBranches--;
                            }
                            beaverRow = 0;
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                        else
                        {
                            if (char.IsLower(matrix[matrix.GetLength(0) - 1, beaverCol]))
                            {
                                collectedBranches.Add(matrix[matrix.GetLength(0) - 1, beaverCol]);
                                countOfcollectedBranches--;
                            }
                            beaverRow = matrix.GetLength(0) - 1;
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                    }
                    else if (currentCommand == "right")
                    {
                        if (beaverCol == matrix.GetLength(1) - 1)
                        {
                            if (char.IsLower(matrix[beaverRow, 0]))
                            {
                                collectedBranches.Add(matrix[beaverRow, 0]);
                                countOfcollectedBranches--;
                            }
                            beaverCol = 0;
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                        else
                        {
                            if (char.IsLower(matrix[beaverRow, matrix.GetLength(1) - 1]))
                            {
                                collectedBranches.Add(matrix[beaverRow, matrix.GetLength(1) - 1]);
                                countOfcollectedBranches--;
                            }
                            beaverCol = matrix.GetLength(1) - 1;
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                    }
                    else if (currentCommand == "left")
                    {
                        if (beaverCol == 0)
                        {
                            if (char.IsLower(matrix[beaverRow, matrix.GetLength(1) - 1]))
                            {
                                collectedBranches.Add(matrix[beaverRow, matrix.GetLength(1) - 1]);
                                countOfcollectedBranches--;
                            }
                            beaverCol = matrix.GetLength(1) - 1;
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                        else
                        {
                            if (char.IsLower(matrix[beaverRow, 0]))
                            {
                                collectedBranches.Add(matrix[beaverRow, 0]);
                                countOfcollectedBranches--;
                            }
                            beaverCol = 0;
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                    }
                }
            }
            else
            {
                if (collectedBranches.Any())
                {
                    collectedBranches.Remove(collectedBranches[collectedBranches.Count - 1]);
                }
            }


            if (countOfcollectedBranches == 0)
            {
                return true;
            }

            return false;
        }

        private static bool EatFish()
        {
            bool result = false;
            if (currentCommand == "up")
            {
                if (beaverRow != 0)
                {
                    result = Move(-beaverRow, 0);
                }
                else
                {
                    result = Move(matrix.GetLength(0) - 1 - beaverRow, 0);
                }
            }
            else if (currentCommand == "down")
            {
                if (beaverRow != matrix.GetLength(0) - 1)
                {
                    result = Move(matrix.GetLength(0) - 1 - beaverRow, 0);
                }
                else
                {
                    result = Move(-beaverRow, 0);
                }
            }
            else if (currentCommand == "left")
            {
                if (beaverCol != 0)
                {
                    result = Move(0, -beaverCol);
                }
                else
                {
                    result = Move(0, matrix.GetLength(1) - 1 - beaverCol);
                }
            }
            else if (currentCommand == "right")
            {
                if (beaverCol != matrix.GetLength(1) - 1)
                {
                    result = Move(0, matrix.GetLength(1) - 1 - beaverCol);
                }
                else
                {
                    result = Move(0, -beaverCol);
                }
            }
            return result;
            
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
