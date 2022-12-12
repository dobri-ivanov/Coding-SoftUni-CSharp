using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private IRepository<IDelicacy> delicacyMenu;
        private IRepository<ICocktail> cocktailMenu;
        private double currentBill;
        private double turnover;
        private bool isReserved;

        public Booth(int boothId, int capacity)
        {
            delicacyMenu = new DelicacyRepository();
            cocktailMenu = new CocktailRepository();
            currentBill = 0;
            turnover = 0;
            isReserved = false;

            BoothId = boothId;
            Capacity = capacity;
        }
        public int BoothId
        {
            get { return boothId; }
            private set { boothId = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value <= 0) throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                capacity = value;   
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => delicacyMenu;

        public IRepository<ICocktail> CocktailMenu => cocktailMenu;


        public double CurrentBill
        {
            get { return currentBill; }
            private set { currentBill = value; }
        }

        public double Turnover
        {
            get { return turnover; }
            private set { turnover = value; }
        }

        public bool IsReserved
        {
            get { return isReserved;}
            private set { isReserved = value;}
        }

        public void ChangeStatus()
        {
            isReserved = !IsReserved;
        }

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:f2} lv");
            sb.AppendLine($"-Cocktail menu:");

            if (cocktailMenu.Models.Any())
            {
                foreach (var cocktail in cocktailMenu.Models)
                {
                    sb.AppendLine($"--{cocktail.ToString()}");
                }
            }

            sb.AppendLine($"-Delicacy menu:");

            if (delicacyMenu.Models.Any())
            {
                foreach (var delicacy in delicacyMenu.Models)
                {
                    sb.AppendLine($"--{delicacy.ToString()}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
