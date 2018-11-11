using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food.Contracts;

namespace WildFarm.Animals.Contracts
{
    public interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        double FoodEaten { get; }

        void ProduceSound();

        void Eat(IFood food);
    }
}
