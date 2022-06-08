using System;
using System.Linq;
using System.Numerics;

namespace _02._From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] numbers = Console.ReadLine().Split(" ");
                if (BigInteger.Parse(numbers[0]) > BigInteger.Parse(numbers[1]))
                {
                    BigInteger sum = 0;
                    for (int j = 0; j < numbers[0].Length; j++)
                    {
                        sum += int.Parse(numbers[0][j].ToString());
                    }
                    Console.WriteLine(sum);
                }
                else
                {
                    BigInteger sum = 0;
                    for (int j = 0; j < numbers[1].Length; j++)
                    {
                        sum += int.Parse(numbers[1][j].ToString());
                    }
                    Console.WriteLine(sum);
                }
            }
        }
    }
}
