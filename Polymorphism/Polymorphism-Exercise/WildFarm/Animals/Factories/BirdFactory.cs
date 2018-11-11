using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Contracts;

namespace WildFarm.Animals.Factories
{
    public class BirdFactory
    {
        public IBird CreateBird(string type, string name, double weight, double wingSize)
        {
            type = type.ToLower();

            switch (type)
            {
                case "owl":
                    return new Owl(name, weight, wingSize);
                case "hen":
                    return new Hen(name, weight, wingSize);
                default:
                    throw new ArgumentException("Invalid animal type!");

            }
        }
    }
}
