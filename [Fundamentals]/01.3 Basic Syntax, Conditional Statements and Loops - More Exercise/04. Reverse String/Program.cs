using System;
using System.Text;

namespace _04._Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            for (int i = text.Length - 1; i >= 0; i--)
            {
                sb.Append(text[i]);
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
