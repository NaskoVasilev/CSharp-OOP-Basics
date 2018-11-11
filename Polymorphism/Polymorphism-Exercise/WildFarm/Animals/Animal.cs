using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Contracts;
using WildFarm.Food.Contracts;

namespace WildFarm.Animals
{
    public abstract class Animal : IAnimal
    {
        public string Name { get; protected set; }

        public double Weight { get; protected set; }

        public double FoodEaten { get; protected set; }

        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public abstract void Eat(IFood food);

        public abstract void ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
