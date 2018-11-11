using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Contracts;

namespace WildFarm.Animals.Birds
{
    public abstract class Bird : Animal, IBird
    {
        public double WingSize { get; protected set; }

        public Bird(string name, double weight,double wingSize) 
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public override string ToString()
        {
            return base.ToString() + $"{WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
