using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public Dictionary<string, Pokemon> Pokemons {get; set;}

        public Trainer(string name)
        {
            Name = name;
            NumberOfBadges = 0;
            this.Pokemons = new Dictionary<string, Pokemon>();
        }
    }
}
