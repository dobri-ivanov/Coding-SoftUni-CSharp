using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }
                if (command == "add")
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        input[i] += 1;
                    }
                }
                else if (command == "multiply")
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        input[i] *= 2;
                    }
                }
                else if (command == "subtract")
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        input[i] -= 1;
                    }
                }
                else if (command == "print")
                {
                    Console.WriteLine(String.Join(" ", input));
                }
            }
        }
    }
}
