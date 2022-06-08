using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            string bookLookingFor = Console.ReadLine();
            string book = Console.ReadLine();
            int counter = 0;
            bool found = false;

            //Loop
            while (book != "No More Books")
            {
                if (book == bookLookingFor)
                {
                    found = true;
                    Console.WriteLine($"You checked {counter} books and found it.");
                    break;
                }
                counter++;
                book = Console.ReadLine();
            }

            //Output
            if (found == false)
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }
        }
    }
}
