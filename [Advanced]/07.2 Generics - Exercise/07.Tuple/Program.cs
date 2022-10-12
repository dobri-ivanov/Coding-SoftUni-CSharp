using System;

namespace _07.Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] line1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Box<string, string> box1 = new Box<string, string>(line1[0] + " " + line1[1], line1[2]);

            string[] line2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = line2[0];
            int litres = int.Parse(line2[1]);
            Box<string, int> box2 = new Box<string, int>(name, litres);

            string[] line3 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int num = int.Parse(line3[0]);
            double num2 = double.Parse(line3[1]);

            Box<int, double> box3 = new Box<int, double>(num, num2);
            Console.WriteLine(box1);
            Console.WriteLine(box2);
            Console.WriteLine(box3);


        }
    }
}
