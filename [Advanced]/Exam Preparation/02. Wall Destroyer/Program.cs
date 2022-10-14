using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace _02._Wall_Destroyer
{
    public class Program
    {
        private static int vankoRow;
        private static int vankoCol;
        private static char[,] wall;

        private static int countOfHoles = 1;
        private static int countOfRods;

        static void Main(string[] args)
        {

            //Input
            int n = int.Parse(Console.ReadLine());

            wall = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string rowInput = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    wall[row, col] = rowInput[col];
                    if (rowInput[col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                    }
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                bool result;
                switch (input)
                {
                    case "up":
                        result = Move(-1, 0);
                        break;
                    case "down":
                        result = Move(+1, 0);
                        break;
                    case "left":
                        result = Move(0, -1);
                        break;
                    case "right":
                        result = Move(0, 1);
                        break;
                    default:
                    result = false;
                        break;
                }
                if (result == true)
                {
                    PrintMatrix();
                    return;
                }
            }
            Console.WriteLine($"Vanko managed to make {countOfHoles} hole(s) and he hit only {countOfRods} rod(s)." );
            PrintMatrix();
        }
        public static bool Move(int rowValue, int colValue)
        {
            int currentRowIndex = vankoRow + rowValue;
            int currentColIndex = vankoCol + colValue;

            if (AreCoordsValid(currentRowIndex, currentColIndex))
            {
                char symbol = wall[currentRowIndex, currentColIndex];

                if (symbol == 'R')
                {
                    Console.WriteLine("Vanko hit a rod!");
                    countOfRods++;
                }
                else if (symbol == 'C')
                {
                    wall[vankoRow, vankoCol] = '*';
                    wall[currentRowIndex, currentColIndex] = 'E';
                    countOfHoles++;
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");
                    return true;
                    
                }
                else if (symbol == '-')
                {
                    wall[vankoRow, vankoCol] = '*';
                    wall[currentRowIndex, currentColIndex] = 'V';
                    vankoRow = currentRowIndex;
                    vankoCol = currentColIndex;
                    countOfHoles++;
                }
                else if (symbol == '*')
                {
                    wall[vankoRow, vankoCol] = '*';
                    wall[currentRowIndex, currentColIndex] = 'V';
                    Console.WriteLine($"The wall is already destroyed at position [{currentRowIndex}, {currentColIndex}]!");
                    vankoRow = currentRowIndex;
                    vankoCol = currentColIndex;
                }
            }
            return false;
        }

        private static bool AreCoordsValid(int currentRowIndex, int currentColIndex)
        {
            if (currentRowIndex >= 0 && currentRowIndex < wall.GetLength(0) && 
                currentColIndex >= 0 && currentColIndex < wall.GetLength(1))
            {
                return true;
            }
            return false;
        }

        public static void PrintMatrix()
        {
            int n = wall.GetLength(0);
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(wall[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
