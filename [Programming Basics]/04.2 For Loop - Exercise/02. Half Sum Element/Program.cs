using System;

namespace _02._Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = int.MinValue;

            //Loop
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
                if (num > max)
                {
                    max = num;
                }
            }
            if (max == (sum - max))
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = " + max);
            }
            else
            {
                int diff = Math.Abs((sum - max) - max);
                Console.WriteLine("No");
                Console.WriteLine("Diff = " + diff);
            }
        }
    }
}
