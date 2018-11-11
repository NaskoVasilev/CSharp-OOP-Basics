using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Contracts;

namespace WildFarm.Animals.Mammals.Feline
{
    public abstract class Feline : Mammal, IFeline
    {
        public string Breed { get; private set; }

        public Feline(string name, double weight, string livingRegion,string breed)
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }
    }
}
