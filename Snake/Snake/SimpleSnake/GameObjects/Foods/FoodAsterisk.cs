using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodAsterisk : Food
    {
        private const int points = 1;
        private const char foodSymbol = '*';

        public FoodAsterisk(Wall wall) : base(wall, foodSymbol, points)
        {
        }
    }
}
