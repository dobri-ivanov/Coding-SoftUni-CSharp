using System;

namespace _05._Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int sites = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            //Loop
            for (int i = 1; i <= sites; i++)
            {
                string site = Console.ReadLine();
                switch (site)
                {
                    case "Facebook":
                        salary -= 150;
                        break;
                    case "Instagram":
                        salary -= 100;
                        break;
                    case "Reddit":
                        salary -= 50;
                        break;
                }
                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }

            }
            if (salary > 0)
            {
                Console.WriteLine(salary);
            }
        }
    }
}
