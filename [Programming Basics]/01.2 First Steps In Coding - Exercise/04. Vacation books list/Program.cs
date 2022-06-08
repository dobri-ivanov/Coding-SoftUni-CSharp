using System;

namespace _04._Vacation_books_list
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int Pages = int.Parse(Console.ReadLine());
            double Hours = double.Parse(Console.ReadLine());
            int Days = int.Parse(Console.ReadLine());

            //Calculation
            double TotalHours = Pages / Hours;
            double TotalDays = TotalHours / Days;

            //Output
            Console.WriteLine(Math.Floor(TotalDays));


        }
    }
}
