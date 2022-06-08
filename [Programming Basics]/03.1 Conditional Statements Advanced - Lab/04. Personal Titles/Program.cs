using System;

namespace _04._Personal_Titles
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double age = double.Parse(Console.ReadLine());
            string sex = Console.ReadLine();

            //Conditional
            if (sex == "m")
            {
                if (age >= 16)
                {
                    Console.WriteLine("Mr.");
                }
                else
                {
                    Console.WriteLine("Master");
                }
            }
            else
            {
                if (age >= 16)
                {
                    Console.WriteLine("Ms.");
                }
                else
                {
                    Console.WriteLine("Miss");
                }
            }
        }
    }
}
