using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food.Contracts;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        private const double weightModifier = 0.35;

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * weightModifier;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
