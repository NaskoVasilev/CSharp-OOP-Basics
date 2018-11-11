using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;
using WildFarm.Food.Contracts;

namespace WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        private const double weightModifier = 0.25;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            if(food is Meat)
            {
                this.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * weightModifier;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
