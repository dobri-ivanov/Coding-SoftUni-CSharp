using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.Fish = new List<Fish>();
        }
        public List<Fish> Fish { get; set; }
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.Fish.Count; } }

        public string AddFish(Fish fish)
        {
            if (fish.FishType == null || fish.FishType == "" || 
                fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            if (Capacity == Count)
            {
                return "Fishing net is full.";
            }
            this.Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }
        public bool ReleaseFish(double weight)
        {
            if (this.Fish.Any(x => x.Weight == weight))
            {
                Fish fish = this.Fish.Find(x => x.Weight == weight);
                this.Fish.Remove(fish);
                return true;
            }
            return false;
            
        }
        public Fish GetFish(string fishType)
        {
            if (this.Fish.Any(x => x.FishType == fishType))
            {
                Fish result = this.Fish.Find(x => x.FishType == fishType);
                return result;
            }
            return null;
        }
        public Fish GetBiggestFish()
        {
            List<Fish> result = Fish.OrderByDescending(x => x.Length).ToList();
            if (Fish.Any())
            {
                return result[0];
            }
            return null;
        }
        public string Report()
        {
            List<Fish> resultFish = Fish.OrderByDescending(x => x.Length).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var fish in resultFish)
            {
                sb.AppendLine(fish.ToString());
            }
            string result = sb.ToString().TrimEnd();
            return String.Format($"Into the {this.Material}:{Environment.NewLine}{result}");
        }

    }
}
