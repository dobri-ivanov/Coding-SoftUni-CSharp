using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Animals = new List<Animal>();
            Name = name;
            Capacity = capacity;
        }

        public List<Animal> Animals { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string AddAnimal(Animal animal)
        {
            if (animal.Species == null || animal.Species == "")
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            if (this.Capacity == this.Animals.Count)
            {
                return "The zoo is full.";
            }

            this.Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }
        public int RemoveAnimals(string species)
        {
            if (!this.Animals.Any(x => x.Species == species))
            {
                return 0;
            }

            int count = 0;
            List<Animal> animalsToBeRemoved = this.Animals.FindAll(x => x.Species == species);

            foreach (var animal in animalsToBeRemoved)
            {
                this.Animals.Remove(animal);
                count++;
            }
            return count;
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> animals = new List<Animal>();
            if (!this.Animals.Any(x => x.Diet == diet))
            {
                return animals;
            }

            animals = this.Animals.FindAll(x => x.Diet == diet);
            return animals;
        }
        public Animal GetAnimalByWeight(double weight)
        {
            if (!this.Animals.Any(x => x.Weight == weight))
            {
                return null;
            }

            Animal animal = this.Animals.First(x => x.Weight == weight);
            return animal;
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = 0;
            if (!this.Animals.Any(x => x.Length >= minimumLength && x.Length <= maximumLength))
            {
                return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
            }

            List<Animal> animals = this.Animals.FindAll(x => x.Length >= minimumLength && x.Length <= maximumLength);
            count = animals.Count;
            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
