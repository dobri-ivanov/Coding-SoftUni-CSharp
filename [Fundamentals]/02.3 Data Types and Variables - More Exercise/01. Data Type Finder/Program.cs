using System;

namespace _01._Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string type = Console.ReadLine();
                bool isInt = int.TryParse(type);
                Console.WriteLine(type.GetType());
            }
        }
    }
}
