using System;

namespace _02._Greater_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            //Conditional
            if (n1 > n2)
            {
                Console.WriteLine(n1);
            }
            else
            {
                Console.WriteLine(n2);
            }
        }
    }
}
