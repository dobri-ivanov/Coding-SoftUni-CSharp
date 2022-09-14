using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            Array.Reverse(array);
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < array.Length; i++)
            {
                stack.Push(array[i]);
            }

            int result = int.Parse(stack.Pop());

            while (stack.Count > 0)
            {
                string token = stack.Pop();
                if (token == "-")
                {
                    result -= int.Parse(stack.Pop());
                }
                else if (token == "+")
                {
                    result += int.Parse(stack.Pop());
                }
            }

            Console.WriteLine(result);
            
        }
    }
}
