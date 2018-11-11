using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Contracts;
using WildFarm.Animals.Mammals;

namespace WildFarm.Animals.Factories
{
    public class MammalFactory
    {
        public IMammal CreateMammal(string type,string name,double weight,string livingRegion)
        {
            type = type.ToLower(); 

            switch(type)
            {
                case "mouse":
                    return new Mouse(name, weight, livingRegion);
                case "dog":
                    return new Dog(name, weight, livingRegion);
                default:
                    throw new ArgumentException("Invalid animal type!");

            }
        }
    }
}
