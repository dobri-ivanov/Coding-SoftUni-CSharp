using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public Trainer(string name, int numberOfBadges)
        {
            Name = name;
            NumberOfBadges = numberOfBadges;
            this.Pokemons = new List<Pokemon>();
        }
    }
}
