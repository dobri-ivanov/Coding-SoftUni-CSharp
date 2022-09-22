using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> studentsGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                decimal grade = decimal.Parse(tokens[1]);

                if (!studentsGrades.ContainsKey(name))
                {
                    studentsGrades.Add(name, new List<decimal>());
                }
                studentsGrades[name].Add(grade);
            }

            foreach (var student in studentsGrades)
            {
                Console.Write($"{student.Key} -> ");

                foreach (var grade in studentsGrades[student.Key])
                {
                    Console.Write($"{grade:f2} ");
                }
                decimal average = studentsGrades[student.Key].Average();
                Console.WriteLine($"(avg: {average:f2})");
            }
        }
    }
}
