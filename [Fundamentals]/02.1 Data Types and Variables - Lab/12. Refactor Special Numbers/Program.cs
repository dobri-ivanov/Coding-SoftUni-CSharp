using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i++)
            {
                int sum = 0;
                string text = i.ToString();
                for (int j = 0; j < text.Length; j++)
                {
                    sum += int.Parse(text[j].ToString());
                }

                if (sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine(i + " -> True");
                }
                else
                {
                    Console.WriteLine(i + " -> False");
                }
            }

        }
    }
}
