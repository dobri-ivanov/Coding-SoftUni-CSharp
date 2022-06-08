using System;

namespace _08._Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int counter = 0;
            double finalGrade = 0;
            int clas = 0;

            for (int i = 1; i <= 12; i++)
            {
               
                double grade = double.Parse(Console.ReadLine());
                finalGrade += grade;
                if (grade < 4.00)
                {
                    if (counter == 0)
                    {
                        clas = i;
                    }
                    counter++;
                }
                if (counter == 2)
                {
                    Console.WriteLine($"{name} has been excluded at {clas} grade");
                    break;
                }
            }
            double avGrade = finalGrade / 12;
            if (counter != 2)
            {
                Console.WriteLine($"{name} graduated. Average grade: {avGrade:f2}");
            }
        }
    }
}
