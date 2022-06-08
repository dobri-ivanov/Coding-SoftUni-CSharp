using System;

namespace _02._Password
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            string input = Console.ReadLine();
            //Loop
            while (input != password)
            {
                input = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {username}!");
        }
    }
}
