using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Contracts;
using WildFarm.Animals.Mammals.Feline;

namespace WildFarm.Animals.Factories
{
    public class FelineFactory
    {
        public IFeline CreateFeline(string type,string name,double weight,string livigRegion,string breed)
        {
            type = type.ToLower();

            switch(type)
            {
                case "cat":
                    return new Cat(name, weight, livigRegion, breed);
                case "tiger":
                    return new Tiger(name, weight, livigRegion, breed);
                default:
                    throw new ArgumentException("Invalid animal type!");

            }
        }
    }
}
