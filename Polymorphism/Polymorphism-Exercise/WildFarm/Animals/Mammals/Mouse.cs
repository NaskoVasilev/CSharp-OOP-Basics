using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;
using WildFarm.Food.Contracts;

namespace WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double weightModifier = 0.1;

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Vegetable || food is Fruit)
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
            Console.WriteLine("Squeak");
        }

        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
