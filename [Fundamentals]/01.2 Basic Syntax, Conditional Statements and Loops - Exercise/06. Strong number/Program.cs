using System;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                int facturielSum = 1;
                int num = int.Parse(number[i].ToString());
                for (int j = num; j > 0; j--)
                {
                    facturielSum = facturielSum * j;
                }
                sum += facturielSum;
            }
            if (sum == int.Parse(number))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
