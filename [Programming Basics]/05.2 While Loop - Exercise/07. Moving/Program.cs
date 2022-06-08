using System;

namespace _07._Moving
{
    class Program
    {
        static void Main(string[] args)
        {

            string outputType = string.Empty;
            //Input
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            //Calculation
            int volume = width * lenght * height;

            //Loop
            string text = Console.ReadLine();
            while (text != "Done")
            {
                int box = int.Parse(text);
                volume -= box;
                if (volume < 0)
                {
                    outputType = "noMoreFreeSpace";
                    break;
                }
                text = Console.ReadLine();
            }

            //Output
            if (outputType == "noMoreFreeSpace")
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(volume)} Cubic meters more.");
            }
            else
            {
                Console.WriteLine($"{volume} Cubic meters left.");
            }
        }
    }
}
