using System;

namespace _07._Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int groups = int.Parse(Console.ReadLine());
            int countMusala = 0;
            int countMonblan = 0;
            int countKili = 0;
            int countK2 = 0;
            int countEverest = 0;
            double allPeople = 0;

            //Loop
            for (int i = 1; i <= groups; i++)
            {
                int people = int.Parse(Console.ReadLine());
                allPeople += people;
                if (people <= 5)
                {
                    countMusala += people;
                }
                else if (people <= 12)
                {
                    countMonblan += people;
                }
                else if (people <= 25)
                {
                    countKili += people;
                }
                else if (people <= 40)
                {
                    countK2 += people;
                }
                else
                {
                    countEverest += people;
                }
            }

            //Calculations
            double persentMusala = countMusala /allPeople * 100;
            double persentMonblan = countMonblan / allPeople * 100;
            double persentKili = countKili / allPeople * 100;
            double persentK2 = countK2 / allPeople * 100;
            double persentEverest = countEverest / allPeople * 100;

            //Ouput
            Console.WriteLine($"{persentMusala:f2}%");
            Console.WriteLine($"{persentMonblan:f2}%");
            Console.WriteLine($"{persentKili:f2}%");
            Console.WriteLine($"{persentK2:f2}%");
            Console.WriteLine($"{persentEverest:f2}%");
        }
    }
}
