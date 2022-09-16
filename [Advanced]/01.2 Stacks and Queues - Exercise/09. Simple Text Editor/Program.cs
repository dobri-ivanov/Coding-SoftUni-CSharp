using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            Stack<string> memory = new Stack<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];

                if (command == "1")
                {
                    string textToAdd = tokens[1];
                    text.Append(textToAdd);
                    memory.Push(text.ToString());
                }
                else if (command == "2")
                {
                    int count = int.Parse(tokens[1]);
                    text.Remove(text.Length - count, count);
                    memory.Push(text.ToString());
                }
                else if (command == "3")
                {
                    int index = int.Parse(tokens[1]);
                    Console.WriteLine($"{text[index - 1]}");
                }
                else if (command == "4")
                {
                    if (memory.Count > 0)
                    {
                        memory.Pop();
                        text.Clear();
                        if (memory.Count > 0)
                        {
                            text.Append(memory.Peek());
                        }
                    }
                }
            }
        }
    }
}