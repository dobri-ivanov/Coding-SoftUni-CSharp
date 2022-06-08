using System;

namespace _06._Vowels_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            string text = Console.ReadLine();

            //Loop
            double sum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];
                if (symbol == 'a')
                {
                    sum++;
                }
                else if (symbol == 'e')
                {
                    sum += 2;
                }
                else if (symbol == 'i')
                {
                    sum += 3;
                }
                else if (symbol == 'o')
                {
                    sum += 4;
                }
                else if (symbol == 'u')
                {
                    sum += 5;
                }
            }

            //Output
            Console.WriteLine(sum);
        }
    }
}
