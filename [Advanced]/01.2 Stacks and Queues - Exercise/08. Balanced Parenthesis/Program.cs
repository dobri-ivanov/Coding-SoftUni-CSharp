using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] symbols = Console.ReadLine().ToCharArray();
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i] == '{' || symbols[i] == '(' || symbols[i] == '[')
                {
                    stack.Push(symbols[i]);
                    continue;
                }
                if (stack.Count == 0)
                {
                    Console.WriteLine("NO");
                    return;
                }
                else if (symbols[i] == '}')
                {
                    if (stack.Pop() != '{')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (symbols[i] == ')')
                {
                    if (stack.Pop() != '(')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (symbols[i] == ']')
                {
                    if (stack.Pop() != '[')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }

            }
            Console.WriteLine("YES");
        }
    }
}