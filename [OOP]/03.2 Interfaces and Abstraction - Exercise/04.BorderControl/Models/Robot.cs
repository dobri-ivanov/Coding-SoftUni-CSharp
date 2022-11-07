using _04.BorderControl.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl.Model
{
    public class Robot
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Model { get; set; }
        public string Id { get; set; }

        public bool ValidateId(string symbols)
        {
            if (this.Id.EndsWith(symbols)) return true;
            return false;
        }
    }
}
