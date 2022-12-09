using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private List<IDecoration> decorations;
        private List<IFish> fishes;

        public Aquarium(string name, int capcity)
        {
            Name = name;
            Capacity = capcity;
            decorations = new List<IDecoration>();
            fishes = new List<IFish>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                name = value;
            }
        }

        public int Capacity
        {
            get { return capacity;}
            private set { capacity = value; }
        }

        public ICollection<IDecoration> Decorations => decorations.AsReadOnly();

        public ICollection<IFish> Fish => fishes.AsReadOnly();
        public int Comfort => decorations.Sum(x => x.Comfort);
        public void AddFish(IFish fish)
        {
            if (Capacity == fishes.Count) throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            fishes.Add(fish);
        }
        public bool RemoveFish(IFish fish)
        {
            return fishes.Remove(fish);
        }

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void Feed()
        {
            fishes.ForEach(x => x.Eat());
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            string fishesOutput = fishes.Any() ? String.Join(", ", fishes.Select(x => x.Name)) : "none";

            sb.AppendLine($"{Name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: {fishesOutput}");
            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();

        }

    }
}
