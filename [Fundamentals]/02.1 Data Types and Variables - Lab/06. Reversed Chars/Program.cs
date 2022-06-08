using System;
using System.Linq;

namespace _06._Reversed_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            char symbol = char.Parse(Console.ReadLine());
            char symbol2 = char.Parse(Console.ReadLine());
            char symbol3 = char.Parse(Console.ReadLine());
            text += symbol3.ToString() + " " + symbol2.ToString() + " " + symbol;

            Console.WriteLine(text);
        }
    }
}
