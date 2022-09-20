using System;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n < 3)
            {
                Console.WriteLine("0");
                return;
            }

            char[,] matrix = new char[n, n];
            int countRemoved = 0;
            for (int row = 0; row < n; row++)
            {
                string rowInput = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowInput[col];
                    
                }
            }

            while (true)
            {
                int countAttackedK = 0;
                int rowK = 0;
                int colK = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int currentCount = CountAttackingKnights(row, col, n, matrix);

                            if (currentCount > countAttackedK)
                            {
                                countAttackedK = currentCount;
                                rowK = row;
                                colK = col;
                            }
                        }
                    }
                }

                if (countAttackedK == 0)
                {
                    break;
                }
                else
                {
                    matrix[rowK, colK] = '0';
                    countRemoved++;
                }
            }

            Console.WriteLine(countRemoved);
        }

        static int CountAttackingKnights(int row, int col, int size, char[,] matrix)
        {
            int count = 0;
            if (IsValidCoords(row - 2, col - 1, size))
            {
                if (matrix[row - 2, col - 1] == 'K')
                {
                    count++;
                }
            }
            if (IsValidCoords(row - 2, col + 1, size))
            {
                if (matrix[row - 2, col + 1] == 'K')
                {
                    count++;
                }
            }
            if (IsValidCoords(row - 1, col + 2, size))
            {
                if (matrix[row - 1, col + 2] == 'K')
                {
                    count++;
                }
            }
            if (IsValidCoords(row + 1, col + 2, size))
            {
                if (matrix[row + 1, col + 2] == 'K')
                {
                    count++;
                }
            }
            if (IsValidCoords(row + 2, col + 1, size))
            {
                if (matrix[row + 2, col + 1] == 'K')
                {
                    count++;
                }
            }
            if (IsValidCoords(row + 2, col - 1, size))
            {
                if (matrix[row + 2, col - 1] == 'K')
                {
                    count++;
                }
            }
            if (IsValidCoords(row - 1, col - 2, size))
            {
                if (matrix[row - 1, col - 2] == 'K')
                {
                    count++;
                }
            }
            if (IsValidCoords(row + 1, col - 2, size))
            {
                if (matrix[row + 1, col - 2] == 'K')
                {
                    count++;
                }
            }

            return count;

        }

        static bool IsValidCoords(int row, int col, int size)
        {
            bool isValid = false;

            if (row >= 0 && row < size && col >= 0 && col < size)
            {
                isValid = true;
            }
            return isValid;
            //Test


        }
    }
}
