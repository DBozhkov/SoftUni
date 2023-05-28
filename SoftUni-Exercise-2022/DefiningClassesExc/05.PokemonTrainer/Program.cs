using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PokemonTrainer
{
    public class Trainer
    {
        public Trainer()
        {

        }

        public Trainer(string name, List<Pokemon> pokemons) : this()
        {
            Name = name;
            Pokemons = pokemons;
        }

        public Trainer(int numberBadges, string name, List<Pokemon> pokemons) : this(name, pokemons)
        {
            NumberOfBadges = numberBadges;
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }

    public class Pokemon
    {
        public Pokemon(string name, string element, int health)
        {
            Name = name;
            Element = element;
            Health = health;
        }
        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            List<Trainer> trainers = new List<Trainer>();
            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] arr = command.Split();
                string trainerName = arr[0];
                string pokemonName = arr[1];
                string pokemonElement = arr[2];
                int pokemonHealth = int.Parse(arr[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                List<Pokemon> pokemons = new List<Pokemon>();
                pokemons.Add(pokemon);
                if (trainers.Any(x => x.Name == $"{trainerName}"))
                {
                    int index = trainers.FindIndex(x => x.Name == trainerName);
                    trainers[index].Pokemons.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName, pokemons);
                    trainers.Add(trainer);
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                switch (input)
                {
                    case "Fire":
                        foreach (var trainer in trainers)
                        {
                            bool isNotValid = true;
                            for (int i = 0; i < trainer.Pokemons.Count; i++)
                            {
                                if (trainer.Pokemons[i].Element == "Fire")
                                {
                                    trainer.NumberOfBadges++;
                                    isNotValid = false;
                                    break;
                                }
                            }

                            if (isNotValid)
                            {
                                if (trainer.Pokemons.Count == 0)
                                {
                                    break;
                                }
                                foreach (var pokemon in trainer.Pokemons.ToList())
                                {
                                    pokemon.Health -= 10;
                                    if (pokemon.Health <= 0)
                                    {
                                        trainer.Pokemons.Remove(pokemon);
                                    }
                                }
                            }
                        }
                        break;

                    case "Water":
                        foreach (var trainer in trainers)
                        {
                            bool isNotValid = true;
                            for (int i = 0; i < trainer.Pokemons.Count; i++)
                            {
                                if (trainer.Pokemons[i].Element == "Water")
                                {
                                    trainer.NumberOfBadges++;
                                    isNotValid = false;
                                    break;
                                }
                            }

                            if (isNotValid)
                            {

                                foreach (var pokemon in trainer.Pokemons.ToList())
                                {
                                    if (trainer.Pokemons.Count == 0)
                                    {
                                        break;
                                    }
                                    pokemon.Health -= 10;
                                    if (pokemon.Health <= 0)
                                    {
                                        trainer.Pokemons.Remove(pokemon);
                                    }
                                }
                            }
                        }
                        break;

                    case "Electricity":
                        foreach (var trainer in trainers)
                        {
                            bool isNotValid = true;
                            for (int i = 0; i < trainer.Pokemons.Count; i++)
                            {
                                if (trainer.Pokemons[i].Element == "Electricity")
                                {
                                    trainer.NumberOfBadges++;
                                    isNotValid = false;
                                    break;
                                }
                            }

                            if (isNotValid)
                            {
                                foreach (var pokemon in trainer.Pokemons.ToList())
                                {
                                    if (trainer.Pokemons.Count == 0)
                                    {
                                        break;
                                    }
                                    pokemon.Health -= 10;
                                    if (pokemon.Health <= 0)
                                    {
                                        trainer.Pokemons.Remove(pokemon);
                                    }
                                }
                            }
                        }
                        break;
                }
            }

            var finalTrainers = trainers.OrderByDescending(x => x.NumberOfBadges).ToList();

            foreach (var trainer in finalTrainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}