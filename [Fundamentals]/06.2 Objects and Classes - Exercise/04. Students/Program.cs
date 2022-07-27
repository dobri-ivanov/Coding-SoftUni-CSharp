using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                string lastName = input[1];
                float grade = float.Parse(input[2]);
                Student student = new Student(name, lastName, grade);
                students.Add(student);
            }
            List<Student> orderedStudents = students.OrderByDescending(s => s.Grade).ToList();
            PrintStudents(orderedStudents);

        }

        static void PrintStudents(List<Student> orderedStudents)
        {
            foreach (var student in orderedStudents)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Grade { get; set; }

        public Student(string name, string lastName, float grade)
        {
            FirstName = name;
            LastName = lastName;
            Grade = grade;
        }
        public override string ToString()
        {
            return String.Format($"{FirstName} {LastName}: {Grade:f2}");
        }
    }
}
