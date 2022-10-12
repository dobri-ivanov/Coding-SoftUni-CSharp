using System;
using System.Linq;

namespace _04.GenericSwapMethodInteger
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

            int[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            box.Swap(indexes[0], indexes[1]);
            Console.WriteLine(box);
        }
    }
}
