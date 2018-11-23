namespace AnimalCentre.Models.Hotels
{
    using Contracts;
    using System;
    using System.Collections.Generic;

    public class Hotel : IHotel
    {
        private const int capacity = 10;
        private Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.Capacity = capacity;
            this.animals = new Dictionary<string, IAnimal>();
        }

        public int Capacity { get; private set; }

        public IReadOnlyDictionary<string, IAnimal> Animals => this.animals;

        public void Accommodate(IAnimal animal)
        {
            if (this.animals.Count >= this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (this.animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            IAnimal animal = this.Animals[animalName];
            animal.Owner = owner;
            animal.IsAdopt = true;
            this.animals.Remove(animalName);
        }
    }
}
