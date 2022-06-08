using System;

namespace _06._Building
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            //Loop
            for (int floor = floors; floor > 0; floor--)
            {
                for (int room = 0; room < rooms; room++)
                {
                    if (floor == floors)
                    {
                        Console.Write($"L{floor}{room}");
                    }
                    else if (floor % 2 == 0)
                    {
                        Console.Write($"O{floor}{room}");
                    }
                    else if (floor % 2 == 1)
                    {
                        Console.Write($"A{floor}{room}");
                    }
                    if (room +1 < rooms)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
