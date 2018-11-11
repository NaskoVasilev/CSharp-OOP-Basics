using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodDollar : Food
    {
        private const int points = 2;
        private const char foodSymbol = '$';

        public FoodDollar(Wall wall) : base(wall, foodSymbol, points)
        {
        }
    }
}
