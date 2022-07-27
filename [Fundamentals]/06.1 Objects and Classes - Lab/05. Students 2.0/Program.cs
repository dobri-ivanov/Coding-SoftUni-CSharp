using System;
using System.Collections.Generic;

namespace _05._Students_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] studentProperties = command.Split();

                if (IsStudentExisting(studentProperties[0], studentProperties[1], students))
                {
                    Student student = students.Find(student => student.firstName == studentProperties[0] && student.lastName == studentProperties[1]);
                    student.age = int.Parse(studentProperties[2]);
                    student.town = studentProperties[3];
                }
                else
                {
                    Student student = new Student(studentProperties[0], studentProperties[1], int.Parse(studentProperties[2]), studentProperties[3]);
                    students.Add(student);
                }
            }

            string filter = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.town == filter)
                {
                    Console.WriteLine($"{student.firstName} {student.lastName} is {student.age} years old.");
                }
            }
        }

        static bool IsStudentExisting(string firstName, string lastName, List<Student> students)
        {
            foreach (Student student in students)
            {
                if (student.firstName == firstName && student.lastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }
    }


    class Student
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public string town { get; set; }

        public Student(string firstName, string lastName, int age, string town)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.town = town;
        }
    }
}
