using System;
using System.Text.RegularExpressions;

namespace _02._Encrypting_Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<separators>.+)>(?<numbers>[0-9]{3})\|(?<lowerLetters>[a-z]{3})\|(?<upperLetters>[A-Z]{3})\|(?<symbols>[^<>]{3})<\k<separators>";
            Regex regex = new Regex(pattern);
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string password = Console.ReadLine();
                Match match = regex.Match(password);
                if (!match.Success)
                {
                    Console.WriteLine("Try another password!");
                }
                else
                {
                    string encryptedPassword = match.Groups["numbers"].Value + match.Groups["lowerLetters"].Value + match.Groups["upperLetters"].Value + match.Groups["symbols"].Value;
                    Console.WriteLine($"Password: {encryptedPassword}");
                }
            }
        }
    }
}
