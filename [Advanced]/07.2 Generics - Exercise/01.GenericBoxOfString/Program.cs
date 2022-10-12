using System;

namespace _01.GenericBoxOfString
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                box.Items.Add(line);
            }
            Console.WriteLine(box);
        }
    }
}
