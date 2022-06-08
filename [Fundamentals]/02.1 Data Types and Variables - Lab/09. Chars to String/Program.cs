using System;

namespace _09._Chars_to_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                text += symbol.ToString();
            }
            Console.WriteLine(text);
        }
    }
}
