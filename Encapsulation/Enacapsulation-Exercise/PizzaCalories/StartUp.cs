using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class StartUp
    {
        public static Dictionary<string, double> flourTypes;
        public static Dictionary<string, double> backingTechniques;
        public static Dictionary<string, double> toppingTypes;

        static void Main(string[] args)
        {
            flourTypes = new Dictionary<string, double>
            {
                { "white", 1.5 },
                { "wholegrain", 1.0 }
            };

            backingTechniques = new Dictionary<string, double>()
            {
                { "crispy" ,0.9 },
                { "chewy",1.1 },
                { "homemade",1 }
            };

            toppingTypes = new Dictionary<string, double>()
            {
                { "meat" ,1.2},
                { "veggies",0.8},
                { "cheese",1.1},
                { "sauce",0.9}
            };

            string input = "";

            try
            {
                string[] pizzaInfo = Console.ReadLine().Split(' ');
                Pizza pizza = new Pizza(pizzaInfo[1]);

                string[] doughInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));
                pizza.Dough = dough;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string command = data[0];
                    string type = data[1];
                    double weight = double.Parse(data[2]);

                    Topping topping = new Topping(type, weight);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return;
            }

        }
    }
}
