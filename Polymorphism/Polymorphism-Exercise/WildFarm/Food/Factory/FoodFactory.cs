using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food.Contracts;

namespace WildFarm.Food.Factory
{
    public class FoodFactory
    {
        public IFood CreateFood(string type,double quantity)
        {
            type = type.ToLower(); 

            switch(type)
            {
                case "vegetable":
                    return new Vegetable(quantity);
                case "fruit":
                    return new Fruit(quantity);
                case "meat":
                    return new Meat(quantity);
                case "seeds":
                    return new Seeds(quantity);
                default:
                    throw new ArgumentException("Invalid food type!");
            }
        }
    }
}
