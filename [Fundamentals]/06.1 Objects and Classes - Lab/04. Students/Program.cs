using System;
using System.Collections.Generic;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                string[] data = input.Split();
                Student student = new Student(data[0], data[1], int.Parse(data[2]), data[3]);
                students.Add(student);
            }
            string city = Console.ReadLine();
            PrintData(students, city);
        }

        static void PrintData(List<Student> students, string city)
        {
            foreach (var student in students)
            {
                if (student.town == city)
                {
                    Console.WriteLine($"{student.firstName} {student.lastName} is {student.age} years old.");
                }
            }
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
