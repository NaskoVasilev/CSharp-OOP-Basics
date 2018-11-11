using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    ThrowArgumentException($"{type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
            private set
            {
                if (!StartUp.toppingTypes.ContainsKey(value.ToLower()))
                {
                    ThrowArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }

        public double Calories
        {
            get
            {
                return (2 * this.weight) * StartUp.toppingTypes[this.type.ToLower()];
            }
        }

        private void ThrowArgumentException(string message)
        {
            throw new ArgumentException(message);
        }
    }
}
