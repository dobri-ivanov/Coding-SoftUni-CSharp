using System;

namespace _05.DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();
            Console.WriteLine(DateModifier.DateDifferance(startDate, endDate));
        }
    }
}
