using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Play_Catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int countCaughtExceptions = 0;
            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                try
                {
                    if (command == "Replace")
                    {
                        int index = int.Parse(tokens[1]);
                        int element = int.Parse(tokens[2]);

                        array[index] = element;
                    }
                    else if (command == "Print")
                    {
                        int startingIndex = int.Parse(tokens[1]);
                        int endingIndex = int.Parse(tokens[2]);

                        List<int> currentElements = new List<int>();
                        for (int i = startingIndex; i <= endingIndex; i++)
                        {
                            currentElements.Add(array[i]);    
                        }
                        Console.WriteLine(String.Join(", ", currentElements));
                    }
                    else if (command == "Show")
                    {
                        int index = int.Parse(tokens[1]);
                        Console.WriteLine(array[index]);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    countCaughtExceptions++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    countCaughtExceptions++;
                }

                if (countCaughtExceptions == 3)
                {
                    Console.WriteLine(String.Join(", ", array));
                    return;
                }
            }
        }
    }
}
