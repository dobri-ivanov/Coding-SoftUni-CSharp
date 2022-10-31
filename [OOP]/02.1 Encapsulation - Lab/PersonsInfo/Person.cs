using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }
        public string FirstName
        {
            get { return this.firstName; }
            set 
            {
                if (value.Length < 3) throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value.Length < 3) throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                this.lastName = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value <= 0) throw new ArgumentException("Age cannot be zero or a negative integer!");
                this.age = value;
            }
        }
        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 460) throw new ArgumentException("Salary cannot be less than 650 leva!");
                this.salary =value;
            }
        }

        public void IncreaseSalary(decimal percantage)
        {
            decimal percant = percantage / 100;
            if (this.Age < 30)
            {
                percant /= 2;
            }
            this.Salary += this.Salary * percant;
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }
    }
}
