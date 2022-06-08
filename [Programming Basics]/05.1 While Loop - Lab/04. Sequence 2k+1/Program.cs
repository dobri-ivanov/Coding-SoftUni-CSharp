using System;

namespace _04._Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int num = int.Parse(Console.ReadLine());
            int number = 1;

            //Loop
            while (number <= num)
            {
                Console.WriteLine(number);
                number = number * 2 + 1;
            }
        }
    }
}
