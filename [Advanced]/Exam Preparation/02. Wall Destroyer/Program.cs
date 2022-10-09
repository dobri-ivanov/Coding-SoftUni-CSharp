using System;
using System.Linq;
using System.Security;

namespace _02._Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countHoles = 0;
            int countRode = 0;
            int previousRow = -1;
            int previousColumn = -1;
            int currentRow = -1;
            int currentColumn = -1;

            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string rowInput = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowInput[col];
                } 
            }


            int[] result = GetCurrentRowIndexes(matrix);

            currentRow = result[0];
            currentColumn = result[1];

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    countHoles++;
                    Console.WriteLine($"Vanko managed to make {countHoles} hole(s) and he hit only {countRode} rod(s).");
                    break;
                }

                if (input == "up")
                {
                    if (IsValidIndexes(currentRow - 1, currentColumn, matrix))
                    {
                        
                        char currentHole = matrix[currentRow - 1, currentColumn];
                        if (currentHole == '-')
                        {
                            countHoles++;
                            matrix[currentRow, currentColumn] = '*';
                            currentRow -= 1;
                            matrix[currentRow, currentColumn] = 'V';
                        }
                        else if (currentHole == 'R')
                        {
                            matrix[currentRow, currentColumn] = 'V';
                            Console.WriteLine("Vanko hit a rod!");
                            countRode++;
                        }
                        else if (currentHole == 'C')
                        {
                            countHoles++;
                            matrix[currentRow, currentColumn] = '*';
                            currentRow -= 1;
                            matrix[currentRow, currentColumn] = 'E';
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {countHoles} hole(s).");
                            break;
                        }
                        else if (currentHole == '*')
                        {
                            countHoles++;
                            matrix[currentRow, currentColumn] = '*';

                            Console.WriteLine($"The wall is already destroyed at position [{currentRow - 1}, {currentColumn}]!");
                            currentRow -= 1;
                            matrix[currentRow, currentColumn] = 'V';
                        }
                    }
                }
                else if (input == "down")
                {
                    if (IsValidIndexes(currentRow + 1, currentColumn, matrix))
                    {
                        char currentHole = matrix[currentRow + 1, currentColumn];
                        if (currentHole == '-')
                        {
                            countHoles++;
                            matrix[currentRow, currentColumn] = '*';
                            currentRow += 1;
                            matrix[currentRow, currentColumn] = 'V';
                        }
                        else if (currentHole == 'R')
                        {
                            matrix[currentRow, currentColumn] = 'V';
                            Console.WriteLine("Vanko hit a rod!");
                            countRode++;
                        }
                        else if (currentHole == 'C')
                        {
                            countHoles++;
                            matrix[currentRow, currentColumn] = '*';
                            currentRow += 1;
                            matrix[currentRow, currentColumn] = 'E';
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {countHoles} hole(s).");
                            break;
                        }
                        else if (currentHole == '*')
                        {
                            countHoles++;
                            matrix[currentRow, currentColumn] = '*';

                            Console.WriteLine($"The wall is already destroyed at position [{currentRow + 1}, {currentColumn}]!");
                            currentRow += 1;
                            matrix[currentRow, currentColumn] = 'V';
                        }
                    }
                }
                else if (input == "right")
                {
                    if (IsValidIndexes(currentRow, currentColumn + 1, matrix))
                    {
                        char currentHole = matrix[currentRow, currentColumn + 1];
                        if (currentHole == '-')
                        {

                            countHoles++;
                            matrix[currentRow, currentColumn] = '*';
                            currentColumn += 1;
                            matrix[currentRow, currentColumn] = 'V';
                        }
                        else if (currentHole == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            countRode++;
                            matrix[currentRow, currentColumn] = 'V';
                        }
                        else if (currentHole == 'C')
                        {
                            countHoles++;
                            matrix[currentRow, currentColumn] = '*';
                            currentColumn += 1;
                            matrix[currentRow, currentColumn] = 'E';
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {countHoles} hole(s).");
                            break;
                        }
                        else if (currentHole == '*')
                        {
                            countHoles++;
                            matrix[currentRow, currentColumn] = '*';

                            Console.WriteLine($"The wall is already destroyed at position [{currentRow}, {currentColumn + 1}]!");
                            currentColumn += 1;
                            matrix[currentRow, currentColumn] = 'V';
                        }
                    }
                }
                else if (input == "left")
                {
                    if (IsValidIndexes(currentRow, currentColumn - 1, matrix))
                    {
                        char currentHole = matrix[currentRow, currentColumn - 1];
                        if (currentHole == '-')
                        {
                            countHoles++;
                            matrix[currentRow, currentColumn] = '*';
                            currentColumn -= 1;
                            matrix[currentRow, currentColumn] = 'V';
                        }
                        else if (currentHole == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            countRode++;
                            matrix[currentRow, currentColumn] = 'V';
                        }
                        else if (currentHole == 'C')
                        {
                            countHoles++;
                            matrix[currentRow, currentColumn] = '*';
                            currentColumn -= 1;
                            matrix[currentRow, currentColumn] = 'E';
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {countHoles} hole(s).");
                            break;
                        }
                        else if (currentHole == '*')
                        {
                            countHoles++;
                            matrix[currentRow, currentColumn] = '*';

                            Console.WriteLine($"The wall is already destroyed at position [{currentRow}, {currentColumn - 1}]!");
                            currentColumn -= 1;
                            matrix[currentRow, currentColumn] = 'V';
                        }
                    }
                }
            }

            //Print
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static bool IsValidIndexes(int currentRow, int currentColumn, char[,] matrix)
        {
            if (currentRow >= 0 && currentRow < matrix.GetLength(0) &&
                currentColumn >= 0 && currentColumn < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }

        static int[] GetCurrentRowIndexes(char[,] matrix)
        {
            int[] result = new int[2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'V')
                    {
                        result[0] = i;
                        result[1] = j;
                        return result;
                    }
                }
            }
            return result;
        }
    }
}
