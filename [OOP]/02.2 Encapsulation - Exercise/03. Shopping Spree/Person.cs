using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Shopping_Spree
{
    public class Person
    {
        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            bagOfProdicts = new List<Product>();
        }
        private string name;
        private double money;
        private List<Product> bagOfProdicts;


        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrEmpty(value)) throw new ArgumentException("Name cannot be empty.");
                this.name = value;
            }
        }
        public double Money
        {
            get { return this.money; }
            set
            {
                if (value < 0) throw new ArgumentException("Money cannot be a negative number.");
                this.money = value;
            }
        }

        public bool BuyProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this.bagOfProdicts.Add(product);
                this.money -= product.Cost;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            List<string> products = new List<string>();
            foreach (var item in bagOfProdicts)
            {
                products.Add(item.Name);
            }
            if (products.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }
            return $"{this.Name} - {String.Join(", ", products)}";
        }

    }
}
