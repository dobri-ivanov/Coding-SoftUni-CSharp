
using _04.BorderControl.Model.Interfaces;
using _04.BorderControl.Models.Interfaces;

namespace _04.BorderControl.Model
{
    internal class Citizen : ICustomObject, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
            this.Food = 0;
            this.Id = id;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }

        public string Birthdate { get; set; }
        public int Food { get; set; }

        public int BuyFood()
        {
            this.Food += 10;
            return 10;
        }

        public bool ValidateBirthdate(string symbol)
        {
            if (this.Birthdate.EndsWith(symbol)) return true;
            return false;
        }
    }
}
