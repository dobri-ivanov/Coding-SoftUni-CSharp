using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string array = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '(')
                {
                    stack.Push(i);
                }
                else if (array[i] == ')')
                {
                    int index = stack.Pop();
                    Console.WriteLine(array.Substring(index, i - index + 1));
                }
            }


        }
    }
}
