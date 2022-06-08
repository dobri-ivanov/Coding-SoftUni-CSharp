using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] bestArray = new int[50];

            for (int i = 0; i < array.Length; i++)
            {
                int[] currentArray = new int[50];
                for (int j = i + 1; j < array.Length; j++)
                {
                    int num1 = array[i];
                    int num2 = array[j];
                    if (num1 != num2)
                    {
                        break;
                    }
                    else
                    {
                        currentArray = 
                    }
                }
                if (currentArray.Length > bestArray.Length)
                {
                    bestArray = currentArray;
                }
            }

            int[] output = new int[bestArray.Length];
            for (int i = 0; i < bestArray.Length; i++)
            {
                output[i] = int.Parse(bestArray[i].ToString());
            }

            Console.WriteLine(String.Join(" ", output));
        }
    }
}
