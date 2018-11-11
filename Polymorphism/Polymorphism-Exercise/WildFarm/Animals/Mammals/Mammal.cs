using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Contracts;

namespace WildFarm.Animals.Mammals
{
    public abstract class Mammal : Animal, IMammal
    {
        public string LivingRegion { get; private set; }

        public Mammal(string name, double weight,string livingRegion)
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }
    }
}
