using System;

namespace _04._Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int countCombinations = 0;
            string outputType = string.Empty;

            //Loop
            for (int i = start; i <= end; i++)
            {
                if (outputType == "found")
                {
                    break;
                }
                for (int j = start; j <= end; j++)
                {
                    countCombinations++;
                    if (i + j == magicNumber)
                    {
                        outputType = "found";
                        Console.WriteLine($"Combination N:{countCombinations} ({i} + {j} = {magicNumber})");
                        break;
                    }
                }
            }

            if (outputType != "found")
            {
                Console.WriteLine($"{countCombinations} combinations - neither equals {magicNumber}");
            }

        }
    }
}
