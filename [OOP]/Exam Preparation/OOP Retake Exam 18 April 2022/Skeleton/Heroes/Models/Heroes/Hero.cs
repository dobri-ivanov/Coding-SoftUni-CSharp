using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentException("Hero name cannot be null or empty.");
                this.name = value;
            }
        }
        public int Health
        {
            get { return health; }
            set
            {
                if (value < 0) throw new ArgumentException("Hero health cannot be below 0.");
                this.health = value;
            }
        }
        public int Armour
        {
            get { return armour; }
            set
            {
                if (value < 0) throw new ArgumentException("Hero armour cannot be below 0.");
                this.armour = value;
            }
        }
        public bool IsAlive
        {
            get
            {
                if (this.Health > 0) return true;
                else return false;
            }
        }

        public IWeapon Weapon
        {
            get { return this.weapon; }
            set
            {
                if (value == null) throw new ArgumentException("Weapon cannot be null.");
                this.weapon = value;
            }
        }


        public void AddWeapon(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            int armourDamage = Math.Min(Armour, points);
            Armour -= armourDamage;
            int healthDamage = Math.Min(Health, points - armourDamage);
            Health -= healthDamage;
        }
    }
}
