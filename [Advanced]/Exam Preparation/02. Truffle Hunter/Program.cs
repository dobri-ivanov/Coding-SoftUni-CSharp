using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace _02._Truffle_Hunter
{
    internal class Program
    {
        public static char[,] matrix;
        public static int blackCount;
        public static int summerCount;
        public static int whiteCount;
        public static int wildBoardCount;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                char[] rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rowInput[j];
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Stop the hunt")
                {
                    break;
                }
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                if (command == "Collect")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    if (AreCoordsValid(row, col))
                    {
                        char symbol = matrix[row, col];
                        if (char.IsLetter(symbol))
                        {
                            matrix[row, col] = '-';
                            CollectTruffle(symbol);
                        }
                    }
                }
                else if (command == "Wild_Boar")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    string direction = tokens[3];
                    StartWildBoard(row, col, direction);
                }
            }
            Console.WriteLine($"Peter manages to harvest {blackCount} black, {summerCount} summer, and {whiteCount} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoardCount} truffles.");
            PrintMatrix();
        }

        private static void StartWildBoard(int row, int col, string direction)
        {
            if (direction == "up")
            {
                int count = 1;
                for (int i = row; i >= 0; i--)
                {
                    if (count % 2 == 1)
                    {
                        char symbol = matrix[i, col];
                        if (char.IsLetter(symbol))
                        {
                            matrix[i, col] = '-';
                            wildBoardCount++;
                        }
                    }
                    count++;
                }
            }
            else if (direction == "down")
            {
                int count = 1;
                for (int i = row; i < matrix.GetLength(0); i++)
                {
                    if (count % 2 == 1)
                    {
                        char symbol = matrix[i, col];
                        if (char.IsLetter(symbol))
                        {
                            matrix[i, col] = '-';
                            wildBoardCount++;
                        }
                    }
                    count++;
                }
            }
            else if (direction == "left")
            {
                int count = 1;
                for (int i = col; i >= 0; i--)
                {
                    if (count % 2 == 1)
                    {
                        char symbol = matrix[row, i];
                        if (char.IsLetter(symbol))
                        {
                            matrix[row, i] = '-';
                            wildBoardCount++;
                        }
                    }
                    count++;
                }
            }
            else if (direction == "right")
            {
                int count = 1;
                for (int i = col; i < matrix.GetLength(1); i++)
                {
                    if (count % 2 == 1)
                    {
                        char symbol = matrix[row, i];
                        if (char.IsLetter(symbol))
                        {
                            matrix[row, i] = '-';
                            wildBoardCount++;
                        }
                    }
                    count++;
                }
            }
        }

        private static void CollectTruffle(char symbol)
        {
            if (symbol == 'B')
            {
                blackCount++;
            }
            else if (symbol == 'S')
            {
                summerCount++;
            }
            else if (symbol == 'W')
            {
                whiteCount++;
            }
        }

        public static bool AreCoordsValid(int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }

        public static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.Write(matrix[i, matrix.GetLength(1) - 1]);
                Console.WriteLine();
            }
        }
    }
}
