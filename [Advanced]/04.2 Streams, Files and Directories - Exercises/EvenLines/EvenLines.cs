namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        private static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder();
            StreamReader reader = new StreamReader(inputFilePath);
            int count = 0;
            string line = string.Empty;

            while (line != null)
            {
                line = reader.ReadLine();

                if (count % 2 == 0)
                {
                    string replacedSymbols = ReplaceSymbols(line);
                    string revercedWords = ReverceWords(replacedSymbols);
                    sb.AppendLine(revercedWords);
                }
                count++;
            }
            return sb.ToString().TrimEnd();
        }

        private static string ReverceWords(string replacedSymbols)
        {
            string[] revercedWords = replacedSymbols.Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
            return String.Join(" ", revercedWords);
        }

        private static string ReplaceSymbols(string line)
        {
            string[] symbolsToReplace = { "-", ",", ".", "!", "?" };

            foreach (var symbol in symbolsToReplace)
            {
                line = line.Replace(symbol, "@");
            }

            return line;
        }
    }
}