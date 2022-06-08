using System;

namespace _06._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNumer = int.MinValue;
            while (true)
            {
                string text = Console.ReadLine();
                if (text == "Stop")
                {
                    break;
                }
                int num = int.Parse(text);

                if (num > maxNumer)
                {
                    maxNumer = num;
                }
            }
            Console.WriteLine(maxNumer);
        }
    }
}
