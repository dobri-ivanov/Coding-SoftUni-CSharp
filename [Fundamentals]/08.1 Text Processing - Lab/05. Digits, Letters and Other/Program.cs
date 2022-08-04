using System;
using System.Text;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            string digits = string.Empty;
            string letters = string.Empty;
            string others = string.Empty;

            foreach (char symbol in line)
            {
                if (char.IsDigit(symbol))
                {
                    digits += symbol;
                }
                else if (char.IsLetter(symbol))
                {
                    letters += symbol;
                }
                else
                {
                    others += symbol;
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}
