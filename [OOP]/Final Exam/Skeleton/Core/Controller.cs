using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
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
using System.Runtime.Serialization;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths;

        public Controller()
        {
            booths = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;
            IBooth booth = new Booth(boothId, capacity);
            booths.AddModel(booth);
            return String.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }
        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IBooth booth = booths.Models.First(x => x.BoothId == boothId);

            IDelicacy delicacy;
            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == nameof(Stolen))
            {
                delicacy = new Stolen(delicacyName);
            }
            else
            {
                return String.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            if (booth.DelicacyMenu.Models.Any(x => x.Name == delicacyName)) return String.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);

            booth.DelicacyMenu.AddModel(delicacy);
            return String.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }
        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth booth = booths.Models.First(x => x.BoothId == boothId);

            ICocktail cocktail;

            if (cocktailTypeName == nameof(Hibernation))
            {
                if (size == "Small" || size == "Middle" || size == "Large")
                {
                    cocktail = new Hibernation(cocktailName, size);
                }
                else
                {
                    return String.Format(OutputMessages.InvalidCocktailSize, size);
                }
            }
            else if (cocktailTypeName == nameof(MulledWine))
            {
                if (size == "Small" || size == "Middle" || size == "Large")
                {
                    cocktail = new MulledWine(cocktailName, size);
                }
                else
                {
                    return String.Format(OutputMessages.InvalidCocktailSize, size);
                }
            }
            else
            {
                return String.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (booth.CocktailMenu.Models.Any(x => x.Name == cocktailName && x.Size == size))
            {
                return String.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            booth.CocktailMenu.AddModel(cocktail);
            return String.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }
        public string ReserveBooth(int countOfPeople)
        {
            IBooth booth = booths.Models
                .Where(x => x.IsReserved == false && x.Capacity >= countOfPeople)
                .OrderBy(x => x.Capacity)
                .ThenByDescending(x => x.BoothId)
                .FirstOrDefault();

            if (booth != null)
            {

                booth.ChangeStatus();
                return String.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
            }
            else
            {
                return String.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }
        }
        public string TryOrder(int boothId, string order)
        {
            IBooth booth = booths.Models.First(x => x.BoothId == boothId);

            string[] tokens = order.Split("/", StringSplitOptions.RemoveEmptyEntries);
            string itemTypeName = tokens[0];
            string itemName = tokens[1];
            int countOfOrderedPieces = int.Parse(tokens[2]);
            string size = String.Empty;

            string item = String.Empty;
            if (itemTypeName == nameof(Hibernation) || itemTypeName == nameof(MulledWine))
            {
                size = tokens[3];
                item = "Cocktail";

            }
            else if (itemTypeName == nameof(Gingerbread) || itemTypeName == nameof(Stolen))
            {
                item = "Delicacy";
            }
            else
            {
                return String.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }


            if (item == "Cocktail")
            {
                if (!booth.CocktailMenu.Models.Any(x => x.Name == itemName))
                {
                    return String.Format(OutputMessages.CocktailStillNotAdded, itemTypeName, itemName);
                }

                if (!booth.CocktailMenu.Models.Any(x => x.GetType().Name == itemTypeName && x.Name == itemName && x.Size == size))
                {
                    return String.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }
                ICocktail cocktail = booth.CocktailMenu.Models.First(x => x.GetType().Name == itemTypeName && x.Name == itemName && x.Size == size);
                booth.UpdateCurrentBill(cocktail.Price * countOfOrderedPieces);
                return String.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, countOfOrderedPieces, itemName);

            }
            else
            {
                if (!booth.DelicacyMenu.Models.Any(x => x.Name == itemName))
                {
                    return String.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }

                if (!booth.DelicacyMenu.Models.Any(x => x.Name == itemName && x.GetType().Name == itemTypeName))
                {
                    return String.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }
                IDelicacy delicacy = booth.DelicacyMenu.Models.First(x => x.Name == itemName && x.GetType().Name == itemTypeName);
                booth.UpdateCurrentBill(delicacy.Price * countOfOrderedPieces);
                return String.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, countOfOrderedPieces, itemName);
            }
        }
        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.First(x => x.BoothId == boothId);
            double currentBill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();
            return $"Bill {currentBill:f2} lv{Environment.NewLine}Booth {boothId} is now available!";
        }
        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.First(x => x.BoothId == boothId);
            return booth.ToString();
        }



    }
}
