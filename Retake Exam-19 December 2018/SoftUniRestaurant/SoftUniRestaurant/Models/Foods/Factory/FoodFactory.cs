using SoftUniRestaurant.Models.Foods.Contracts;
using System;

namespace SoftUniRestaurant.Models.Foods.Factory
{
    public class FoodFactory
    {
        //Reflection is not allowed
        //public IFood CreateFood(string type, string name, decimal price)
        //{
        //    Type foodType = Assembly.GetExecutingAssembly()
        //        .GetTypes()
        //        .FirstOrDefault(t => t.Name == type);

        //    return (IFood)Activator.CreateInstance(foodType, name, price);
        //}

        public IFood CreateFood(string type, string name, decimal price)
        {
            switch (type)
            {
                case "Dessert":
                    return new Dessert(name, price);
                case "MainCourse":
                    return new MainCourse(name, price);
                case "Salad":
                    return new Salad(name, price);
                case "Soup":
                    return new Soup(name, price);
                default:
                    throw new ArgumentException("Invalid food type!");
            }
        }
    }
}
