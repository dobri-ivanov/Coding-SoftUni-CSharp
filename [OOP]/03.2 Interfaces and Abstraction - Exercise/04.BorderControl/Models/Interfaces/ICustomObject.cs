using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl.Model.Interfaces
{
    public interface ICustomObject
    {
        public string Birthdate { get; set; }

        public bool ValidateBirthdate(string symbols);
    }
}
