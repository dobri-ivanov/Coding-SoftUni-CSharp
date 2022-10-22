using System;
using System.Linq;
using System.Numerics;

namespace _02._Rally_Racing
{
    internal class Program
    {
        public static char[,] matrix;
        public static int carRow = 0;
        public static int carCol = 0;
        public static char currentSymbol;
        public static int distancePassed = 0;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string carNumber = Console.ReadLine();
            matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                char[] rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rowInput[j];
                }
            }

            matrix[0, 0] = 'C';
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    Console.WriteLine($"Racing car {carNumber} DNF.");
                    break;
                }

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
                if (currentSymbol == 'F')
                {
                    Console.WriteLine($"Racing car {carNumber} finished the stage!");
                    break;
                }
            }
            Console.WriteLine($"Distance covered {distancePassed} km.");
            PrintMatrix();
            
        }

        public static void Move(int rowValue, int colValue)
        {
            int currentRow = carRow + rowValue;
            int currentCol = carCol + colValue;

            if (AreCoordsValid(currentRow, currentCol))
            {
                currentSymbol = matrix[currentRow, currentCol];

                if (currentSymbol == '.')
                {
                    matrix[carRow, carCol] = '.';
                    matrix[currentRow, currentCol] = 'C';
                    carRow = currentRow;
                    carCol = currentCol;
                    distancePassed += 10;
                }
                else if (currentSymbol == 'T')
                {
                    matrix[carRow, carCol] = '.';
                    matrix[currentRow, currentCol] = '.';
                    int secondLocationRow = 0;
                    int secondLocationCol = 0;

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (matrix[i, j] == 'T')
                            {
                                secondLocationRow = i;
                                secondLocationCol = j;
                            }
                        }
                    }
                    matrix[secondLocationRow, secondLocationCol] = 'C';
                    carRow = secondLocationRow;
                    carCol = secondLocationCol;
                    distancePassed += 30;
                }
                else if (currentSymbol == 'F')
                {
                    matrix[carRow, carCol] = '.';
                    matrix[currentRow, currentCol] = 'C';
                    carRow = currentRow;
                    carCol = currentCol;
                    distancePassed += 10;
                }
            }
        }
        private static bool AreCoordsValid(int currentRow, int currentCol)
        {
            if (currentRow >= 0 && currentRow < matrix.GetLength(0) && currentCol >= 0 && currentCol < matrix.GetLength(1))
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
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
