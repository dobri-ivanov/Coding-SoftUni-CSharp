using System;

namespace _02.GenericBoxOfInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int line = int.Parse(Console.ReadLine());
                box.Items.Add(line);
            }
            Console.WriteLine(box);
        }
    }
}
