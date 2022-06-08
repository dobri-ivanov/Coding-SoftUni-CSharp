using System;

namespace _05._Character_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            string text = Console.ReadLine();

            //Loop
            for (int i = 0; i < text.Length; i++)
            {
                Console.WriteLine(text[i]);
            }
        }
    }
}
