using System;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            string output = RepeatText(text, n);
            Console.WriteLine(output);
        }

        static string RepeatText(string text, int n)
        {
            string result = string.Empty;

            for (int i = 0; i < n; i++)
            {
                result += text;
            }
            return result;
        }
    }
}
