using System;
using System.Linq;

namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            bool isTop = true; 

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    int num1 = array[i];
                    int num2 = array[j];
                    if (num1 <= num2)
                    {
                        isTop = false;
                        break;
                    }
                }
                if (isTop)
                {
                    Console.Write(array[i] + " ");
                }
                isTop = true;
            }
        }
    }
}
