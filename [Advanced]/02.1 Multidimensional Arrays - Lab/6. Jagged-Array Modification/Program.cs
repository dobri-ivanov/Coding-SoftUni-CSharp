using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] rowInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int size = rowInput.Length;
                jaggedArray[row] = new int[size];
                for (int col = 0; col < size; col++)
                {
                    jaggedArray[row][col] = rowInput[col];
                }  
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "END")
                {
                    for (int row = 0; row < rows; row++)
                    {
                        int size = jaggedArray[row].Length;
                        for (int col = 0; col < size; col++)
                        {
                            Console.Write(jaggedArray[row][col] + " ");
                        }
                        Console.WriteLine();
                    }
                    return;
                }
                else if (input[0] == "Add")
                {
                    int rowCoord = int.Parse(input[1]);
                    int colCoord = int.Parse(input[2]);
                    int value = int.Parse(input[3]);

                    if (rowCoord < rows && rowCoord >= 0)
                    {
                        if (colCoord < jaggedArray[rowCoord].Length && colCoord >= 0)
                        {
                            jaggedArray[rowCoord][colCoord] += value;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (input[0] == "Subtract")
                {
                    int rowCoord = int.Parse(input[1]);
                    int colCoord = int.Parse(input[2]);
                    int value = int.Parse(input[3]);

                    if (rowCoord < rows && rowCoord >= 0)
                    {
                        if (colCoord < jaggedArray[rowCoord].Length && colCoord >= 0)
                        {
                            jaggedArray[rowCoord][colCoord] -= value;
                        }  
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
            }
        }
    }
}
