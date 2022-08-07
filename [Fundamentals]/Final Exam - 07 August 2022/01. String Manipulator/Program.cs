using System;
using System.Text;

namespace _01._String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input2 = Console.ReadLine();
            while (input2 != "End")
            {
                string[] tokens = input2.Split();
                string command = tokens[0];

                switch (command)
                {
                    case "Translate":
                        char symbol = char.Parse(tokens[1]);
                        char replacement = char.Parse(tokens[2]);
                        text = text.Replace(symbol, replacement);
                        Console.WriteLine(text);
                        break;
                    case "Includes":
                        string substring = tokens[1];
                        bool isIncludesText = text.Contains(substring);
                        Console.WriteLine(isIncludesText);
                        break;
                    case "Start":
                        string startingText = tokens[1];
                        bool isStartsWithGivenString = true;
                        for (int i = 0; i < startingText.Length; i++)
                        {
                            if (startingText[i] != text[i])
                            {
                                isStartsWithGivenString = false;
                            }
                        }
                        Console.WriteLine(isStartsWithGivenString);
                        break;
                    case "Lowercase":
                        text = text.ToLower();
                        Console.WriteLine(text);
                        break;
                    case "FindIndex":
                        char symbol2 = char.Parse(tokens[1]);
                        int result = text.LastIndexOf(symbol2);
                        Console.WriteLine(result);
                        break;
                    case "Remove":
                        int startIndex = int.Parse(tokens[1]);
                        int count = int.Parse(tokens[2]);
                        text = text.Remove(startIndex, count);
                        Console.WriteLine(text);
                        break;
                    default:
                        break;
                }
                input2 = Console.ReadLine();
            }
        }
    }
}
