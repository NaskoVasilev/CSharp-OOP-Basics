using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        public int FoodPoints { get; private set; }
        private char foodSymbol;
        private Wall wall;
        private Random random;

        public Food(Wall wall, char foodSymbol, int points)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            this.FoodPoints = points;
            this.random = new Random();
        }

        public void SetRandomPosition(Queue<Point> snake)
        {
            this.LeftX = random.Next(2, wall.LeftX - 2);
            this.TopY = random.Next(2, wall.TopY - 2);

            bool isPointOfSnake = snake.Any(p => p.TopY == this.TopY && p.LeftX == this.LeftX);

            while (isPointOfSnake)
            {
                this.LeftX = random.Next(2, wall.LeftX - 2);
                this.TopY = random.Next(2, wall.TopY - 2);

                isPointOfSnake = snake.Any(p => p.TopY == this.TopY && p.LeftX == this.LeftX);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(this.foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snake)
        {
            return snake.LeftX == this.LeftX
                && snake.TopY == this.TopY;
        }
    }
}
