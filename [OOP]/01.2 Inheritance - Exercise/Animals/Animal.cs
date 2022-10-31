using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentException("Invalid input!");
                this.name = value;
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid input!");
                this.age = value;
            }
        }
        public string Gender
        {
            get { return gender; } 
            set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentException("Invalid input!");
                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return "Some basic sound.";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}");
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.AppendLine($"{ProduceSound()}");
            return sb.ToString().TrimEnd();
        }
    }
}
