using System;

namespace _06._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int minNum = int.MaxValue;
            while (true)
            {
                string text = Console.ReadLine();
                if (text == "Stop")
                {
                    break;
                }
                int num = int.Parse(text);

                if (num < minNum)
                {
                    minNum = num;
                }
            }
            Console.WriteLine(minNum);
        }
    }
}
