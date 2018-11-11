using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodHash : Food
    {
        private const int points = 3;
        private const char foodSymbol = '#';

        public FoodHash(Wall wall) : base(wall, foodSymbol, points)
        {
        }
    }
}
