using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingSource = int.Parse(Console.ReadLine());
            int countDays = 0;
            int spices = 0;

            while (startingSource >= 100)
            {
                spices += startingSource - 26;
                startingSource -= 10;
                countDays++;
                if (startingSource < 100)
                {
                    spices -= 26;
                }
            }

            Console.WriteLine(countDays);
            Console.WriteLine(spices);
        }
    }
}
