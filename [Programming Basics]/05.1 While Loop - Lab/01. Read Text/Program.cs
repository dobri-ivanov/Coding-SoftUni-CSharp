using System;

namespace _01._Read_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            string text = Console.ReadLine();

            //Loop
            while (text != "Stop")
            {
                Console.WriteLine(text);
                text = Console.ReadLine();
            }
        }
    }
}
