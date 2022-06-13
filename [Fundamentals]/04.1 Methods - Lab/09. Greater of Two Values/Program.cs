using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            if (type == "int")
            {
                int value1 = int.Parse(Console.ReadLine());
                int value2 = int.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(value1, value2));
            }
            else if (type == "char")
            {
                char value1 = char.Parse(Console.ReadLine());
                char value2 = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(value1, value2));
            }
            else if (type == "string")
            {
                string value1 = Console.ReadLine();
                string value2 = Console.ReadLine();
                Console.WriteLine(GetMax(value1, value2));
            }
        }
        static int GetMax(int value1, int value2)
        {
            if (value1 > value2)
            {
                return value1;
            }
            return value2;
        }
        static char GetMax(char value1, char value2)
        {
            if (value1 > value2)
            {
                return value1;
            }
            return value2;
        }
        static string GetMax(string value1, string value2)
        {
            int result = value2.CompareTo(value2);
            if (result > 0)
            {
                return value1;
            }
            return value2;
        }
    }
}
