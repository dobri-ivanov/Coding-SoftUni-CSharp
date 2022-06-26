using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            List<int> numbers = new List<int>();
            numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                if (command == "Finish")
                {
                    break;
                }
                int value = int.Parse(input[1]);
                switch (command)
                {
                    case "Add":
                        Add(numbers, value);
                        break;
                    case "Remove":
                        Remove(numbers, value);
                        break;
                    case "Replace":
                        int value2 = int.Parse(input[2]);
                        Replace(numbers, value, value2);
                        break;
                    case "Collapse":
                        Collapse(numbers, value);
                        break;
                    default:
                        break;
                }
            }
            PrintList(numbers);
        }

        static void Collapse(List<int> numbers, int value)
        {
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (numbers[i] < value)
                {
                    numbers.RemoveAt(i);
                }
            }
        }

        static void Replace(List<int> numbers, int value, int value2)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == value)
                {
                    numbers[i] = value2;
                    return;
                }
            }
        }

        static void Remove(List<int> numbers, int value)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == value)
                {
                    numbers.RemoveAt(i);
                    return;
                }
            }
        }

        static void Add(List<int> numbers, int value)
        {
            numbers.Add(value);
        }

        static void PrintList(List<int> numbers)
        {
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
