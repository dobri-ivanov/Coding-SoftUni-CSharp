using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Dictionary<char, int> chars = new Dictionary<char, int>();
            string text = Console.ReadLine();

            foreach (var symbol in text)
            {
                if (!chars.ContainsKey(symbol))
                {
                    chars[symbol] = 0;
                }
                chars[symbol]++;
            }

            chars = chars.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var symbol in chars)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}