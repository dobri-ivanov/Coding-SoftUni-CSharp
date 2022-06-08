using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int persons = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int courses = 0;

            if (persons % capacity == 0)
            {
                courses = persons / capacity;
            }
            else
            {
                courses = persons / capacity + 1;
            }
            Console.WriteLine(courses);
        }
    }
}
