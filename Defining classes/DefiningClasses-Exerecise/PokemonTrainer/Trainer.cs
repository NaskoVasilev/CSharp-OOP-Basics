using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    class Trainer
    {
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public Trainer(string name)
        {
            this.Name = name;
            this.NumberOfBadges = 0;
            this.Pokemons = new List<Pokemon>();
        }
    }
}
