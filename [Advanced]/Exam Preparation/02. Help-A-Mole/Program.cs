using System;

namespace _02._Help_A_Mole
{
    internal class Program
    {
        public static char[,] matrix;
        public static int moleRow;
        public static int moleCol;
        public static int points;

        static void Main(string[] args)
        {
            points = 0;
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                string rowInput = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rowInput[j];
                    if (rowInput[j] == 'M')
                    {
                        moleRow = i;
                        moleCol = j;
                    }
                }
            }

            while (true)
            {
                string direction = Console.ReadLine();
                if (direction == "End")
                {
                    Console.WriteLine("Too bad! The Mole lost this battle!");
                    Console.WriteLine($"The Mole lost the game with a total of {points} points.");
                    break;
                }

                if (direction == "up")
                {
                    Move(-1, 0);
                }
                else if (direction == "down")
                {
                    Move(1, 0);
                }
                else if (direction == "left")
                {
                    Move(0, -1);
                }
                else if (direction == "right")
                {
                    Move(0, 1);
                }

                if (points >= 25)
                {
                    Console.WriteLine("Yay! The Mole survived another game!");
                    Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
                    PrintMatrix();
                    return;
                }
            }


            PrintMatrix();
        }

        public static void Move(int rowValue, int colValue)
        {
            int currentRow = moleRow + rowValue;
            int currentCol = moleCol + colValue;

            if (!AreCoordsValid(currentRow, currentCol))
            {
                Console.WriteLine("Don't try to escape the playing field!");
                return;
            }
            matrix[moleRow, moleCol] = '-';
            moleRow = currentRow;
            moleCol = currentCol;

            char symbol = matrix[moleRow, moleCol];

            if (symbol == '-')
            {
                matrix[moleRow, moleCol] = 'M';
            }
            else if (char.IsDigit(symbol))
            {
                int currentPoints = int.Parse(matrix[moleRow, moleCol].ToString());
                points += currentPoints;
                matrix[moleRow, moleCol] = 'M';
            }
            else if (char.IsLetter(symbol))
            {
                matrix[moleRow, moleCol] = '-';

                int secondLocationRow = 0;
                int secondLocationCol = 0;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == 'S')
                        {
                            secondLocationRow = i;
                            secondLocationCol = j;
                        }
                    }
                }

                moleRow = secondLocationRow;
                moleCol = secondLocationCol;
                matrix[moleRow, moleCol] = 'M';
                points -= 3;
            }
        }

        public static bool AreCoordsValid(int currentRow, int currentCol)
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
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
