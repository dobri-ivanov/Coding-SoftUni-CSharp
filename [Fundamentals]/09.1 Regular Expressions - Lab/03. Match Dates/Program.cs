using System;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();

            //string pattern = @"\b(?<day>\d{2})(?<separator>.{1})(?<month>[A-Z][a-z]{2})\k<separator>(?<year>\d{4})\b";

            //Regex regex = new Regex(pattern);
            //MatchCollection matches = regex.Matches(input);

            //foreach (Match match in matches)
            //{
            //    Console.WriteLine($"Day: {match.Groups["day"].Value}, Month: {match.Groups["month"].Value}, Year: {match.Groups["year"].Value}");
            //}

            string t = "Hello World";
            Console.WriteLine(t.Substring(3,4));
        }

    }
}
