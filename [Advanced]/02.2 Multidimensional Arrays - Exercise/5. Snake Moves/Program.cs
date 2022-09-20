using System;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string word = Console.ReadLine();

            char[,] matrix = new char[tokens[0], tokens[1]];

            int currentWordIndex = 0;

            for (int row = 0; row < tokens[0]; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < tokens[1]; col++)
                    {
                        if (currentWordIndex == word.Length)
                        {
                            currentWordIndex = 0;
                        }
                        matrix[row, col] = word[currentWordIndex];
                        currentWordIndex++;
                    }
                }
                else
                {
                    for (int col = tokens[1] - 1; col >= 0; col--)
                    {
                        if (currentWordIndex == word.Length)
                        {
                            currentWordIndex = 0;
                        }
                        matrix[row, col] = word[currentWordIndex];
                        currentWordIndex++;
                    }
                }
            }

            for (int row = 0; row < tokens[0]; row++)
            {
                for (int col = 0; col < tokens[1]; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
