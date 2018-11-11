using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;
using WildFarm.Food.Contracts;

namespace WildFarm.Animals.Mammals.Feline
{
    public class Cat : Feline
    {
        private const double weightModifier = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Meat || food is Vegetable)
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
            Console.WriteLine("Meow");
        }

        public override string ToString()
        {
            return base.ToString() + $"{Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
