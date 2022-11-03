using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Pizza_Calories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dought dought)
        {
            this.Name = name;
            this.Dought = dought;
            this.toppings = new List<Topping>();

        }

        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrEmpty(value) || value.Length > 15) throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                this.name = value;
            }
        }
        public Dought Dought { get; set; }
        private int Count { get { return this.toppings.Count; } }
        private double TotalCalories
        {
            get 
            {
                double totalCalories = 0;
                totalCalories += this.Dought.CalculateCalories();
                foreach (var item in this.toppings)
                {
                    totalCalories += item.CalculateCalories();
                }
                return totalCalories;
            }
        }
        public void AddTopping(Topping topping)
        {
            if (Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {TotalCalories:f2} Calories.";
        }

    }
}
