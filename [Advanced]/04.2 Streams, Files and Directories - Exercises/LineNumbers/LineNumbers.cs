namespace LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        private static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line = string.Empty;
                int countLines = 1;

                while (true)
                {
                    line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    int countLetters = 0;
                    int countSymbols = 0;

                    foreach (var element in line)
                    {
                        if (char.IsPunctuation(element))
                        {
                            countSymbols++;
                        }
                        else if (char.IsLetter(element))
                        {
                            countLetters++;
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        writer.Write($"Line {countLines}: {line} ({countLetters})({countSymbols})");
                    }

                    countLines++;
                }
            }
        }
    }
}