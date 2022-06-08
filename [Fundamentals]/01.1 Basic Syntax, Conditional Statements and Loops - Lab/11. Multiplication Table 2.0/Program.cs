using System;

namespace _11._Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int multi = int.Parse(Console.ReadLine());

            for (int i = multi; i < 11; i++)
            {
                Console.WriteLine($"{n} X {i} = {n * i}");
            }

            if (multi > 10)
            {
                Console.WriteLine($"{n} X {multi} = {n * multi}");
            }
        }
    }
}
