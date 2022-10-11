using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainersByNames = new Dictionary<string, Trainer>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Tournament")
                {
                    break;
                }
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                if (!trainersByNames.ContainsKey(trainerName))
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemonName, pokemon);
                    trainersByNames.Add(trainerName, trainer);
                }
                else
                {
                    trainersByNames[trainerName].Pokemons.Add(pokemonName, pokemon);
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string command = input;
                foreach (var trainer in trainersByNames)
                {
                    bool hasPokemon = false;
                    foreach (var pokemon in trainer.Value.Pokemons)
                    {
                        if (pokemon.Value.Element == command)
                        {
                            hasPokemon = true;
                            trainer.Value.NumberOfBadges++;
                            break;
                        }
                    }
                    if (!hasPokemon)
                    {
                        foreach (var pokemon in trainer.Value.Pokemons)
                        {
                            pokemon.Value.Health -= 10;
                            if (pokemon.Value.Health <= 0)
                            {
                                trainer.Value.Pokemons.Remove(pokemon.Key);
                            }
                        }
                    }

                }
            }

            trainersByNames = trainersByNames.OrderByDescending(x => x.Value.NumberOfBadges).ToDictionary(x => x.Key, x => x.Value);

            foreach (var trainer in trainersByNames)
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.NumberOfBadges} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}
