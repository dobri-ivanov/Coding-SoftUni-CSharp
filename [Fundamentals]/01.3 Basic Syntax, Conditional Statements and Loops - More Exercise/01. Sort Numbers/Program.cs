using System;

namespace _01._Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            int[] array = { n1, n2, n3 };

            int first = int.MinValue;
            int second = int.MinValue;
            int third = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > first)
                {
                    third = second;
                    second = first;
                    first = array[i];
                }
                else if (array[i] > second)
                {
                    third = second;
                    second = array[i];
                }
                else
                {
                    third = array[i];
                }
            }

            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
        }
    }
}
