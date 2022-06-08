using System;

namespace _04._Password_Guess
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            string pass = Console.ReadLine();

            //Conditional
            if (pass == "s3cr3t!P@ssw0rd")
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
