using System;

namespace _06.GenericCountMethodDouble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box<double> box = new Box<double>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double line = double.Parse(Console.ReadLine());
                box.Items.Add(line);
            }

            double text = double.Parse(Console.ReadLine());
            Console.WriteLine(box.Count(text));
        }
    }
}
