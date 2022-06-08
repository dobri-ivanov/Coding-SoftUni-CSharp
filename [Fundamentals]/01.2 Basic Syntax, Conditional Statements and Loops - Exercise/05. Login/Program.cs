using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();
            string password = string.Empty;
            int count = 0;

            for (int i = user.Length - 1; i >= 0; i--)
            {
                char symbol = user[i];
                password += symbol;
            }
            while (true)
            {
                string attempt = Console.ReadLine();
                
                if (password == attempt)
                {
                    Console.WriteLine($"User {user} logged in.");
                    break;
                }
                else
                {
                    if (count == 3)
                    {
                        Console.WriteLine($"User {user} blocked!");
                        break;
                    }
                    count++;
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }
        }
    }
}
