using System;

namespace _11._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int n = int.Parse(Console.ReadLine());
            double totalSum = 0;

            for (int i = 0; i < n; i++)
            {
                double price = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsules = int.Parse(Console.ReadLine());
                double sum = (days * capsules) * price;
                Console.WriteLine($"The price for the coffee is: ${sum:f2}");
                totalSum += sum;
            }
            Console.WriteLine($"Total: ${totalSum:f2}");
        }
    }
}
