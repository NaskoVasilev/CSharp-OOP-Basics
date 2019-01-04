using SoftUniRestaurant.Models.Drinks.Contracts;
using System;

namespace SoftUniRestaurant.Models.Drinks.Factory
{
    public class DrinkFactory
    {
        //Reflection is not allowed
        //public IDrink CreateDrink(string type, string name, int servingSize, string brand)
        //{
        //    Type drinkType = Assembly.GetExecutingAssembly()
        //        .GetTypes()
        //        .FirstOrDefault(t => t.Name == type);

        //    return (IDrink)Activator.CreateInstance(drinkType, name, servingSize, brand);
        //}

        public IDrink CreateDrink(string type, string name, int servingSize, string brand)
        {
            switch(type)
            {
                case "Alcohol":
                    return new Alcohol(name, servingSize, brand);
                case "FuzzyDrink":
                    return new FuzzyDrink(name, servingSize, brand);
                case "Juice":
                    return new Juice(name, servingSize, brand);
                case "Water":
                    return new Water(name, servingSize, brand);
                default:
                    throw new ArgumentException("Invalid type!");
            }
        }
    }
}
