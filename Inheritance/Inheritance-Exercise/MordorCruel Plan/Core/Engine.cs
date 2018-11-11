using MordorCruelPlan.Foods;
using MordorCruelPlan.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MordorCruelPlan.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] eatenFood = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int points = 0;
            foreach (var foodType in eatenFood)
            {
                Food currentFood = FoodFactory.CreateFood(foodType);
                points += currentFood.Happiness;
            }

            string mood = "";

            if (points < -5)
            {
                mood = "Angry";
            }
            else if (points <= 0)
            {
                mood = "Sad";
            }
            else if (points <= 15)
            {
                mood = "Happy";
            }
            else
            {
                mood = "JavaScript";
            }

            Console.WriteLine(points);
            Console.WriteLine(mood);
        }
    }
}
