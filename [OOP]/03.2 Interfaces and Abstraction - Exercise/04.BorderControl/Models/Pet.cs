using _04.BorderControl.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl.Models
{
    public class Pet : ICustomObject
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
        public string Name { get; set; }
        public string Birthdate { get; set; }

        public bool ValidateBirthdate(string symbols)
        {
            if (this.Birthdate.EndsWith(symbols)) return true;
            return false;
        }
    }
}
