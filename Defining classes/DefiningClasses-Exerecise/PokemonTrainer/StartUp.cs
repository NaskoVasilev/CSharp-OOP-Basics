using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            string command = "";

            while ((command = Console.ReadLine())!= "Tournament")
            {
                string[] data = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = data[0];
                string pokemonName = data[1];
                string element = data[2];
                int health = int.Parse(data[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }
                trainers[trainerName].Pokemons.Add(new Pokemon(pokemonName, element, health));
            }

            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Any(x => x.Element == command))
                    {
                        trainer.Value.NumberOfBadges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Value.Pokemons.Count; i++)
                        {
                            if (trainer.Value.Pokemons[i].Health - 10 <= 0)
                            {
                                trainer.Value.Pokemons.RemoveAt(i);
                                i--;
                            }
                            else
                            {
                                trainer.Value.Pokemons[i].Health -= 10;
                            }
                        }
                    }
                }
            }
            foreach (var trainer in trainers.OrderByDescending(t=>t.Value.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.NumberOfBadges} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}
