using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string backingTechnique;
        private double weight;

        public Dough(string flourType, string backingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BackingTechnique = backingTechnique;
            this.Weight = weight;
        }

        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    ThrowArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (!StartUp.flourTypes.ContainsKey(value.ToLower()))
                {
                    ThrowArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }

        public string BackingTechnique
        {
            get { return backingTechnique; }
            private set
            {
                if (!StartUp.backingTechniques.ContainsKey(value.ToLower()))
                {
                    ThrowArgumentException("Invalid type of dough.");
                }
                backingTechnique = value;
            }
        }

        public double Calories
        {
            get
            {
                double typeMultiplier = StartUp.flourTypes[this.flourType.ToLower()];
                double backingMultiplier = StartUp.backingTechniques[this.backingTechnique.ToLower()];
                return (2 * weight) * typeMultiplier * backingMultiplier;
            }
        }

        private void ThrowArgumentException(string message)
        {
            throw new ArgumentException(message);
        }
    }
}
