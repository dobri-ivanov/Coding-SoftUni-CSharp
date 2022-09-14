using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());

            var input = Console.ReadLine().Split();
            string command = input[0].ToLower();
            while (command != "end")
            {
                if (command == "add")
                {
                    int firstNum = int.Parse(input[1]);
                    int secondNum = int.Parse(input[2]);

                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else if (command == "remove")
                {
                    if (stack.Count >= int.Parse(input[1]))
                    {
                        int num = int.Parse(input[1]);
                        for (int i = 0; i < num; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                input = Console.ReadLine().Split();
                command = input[0].ToLower();
            }
            Console.WriteLine("Sum: " + stack.Sum()); ;
        }
    }
}
