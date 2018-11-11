using SimpleSnake.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char snakeSymbol = '\u25CF';
        private Queue<Point> snakeElements;
        private Food[] foods;
        private Wall wall;
        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;
        private Random random;

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.snakeElements = new Queue<Point>();
            this.random = new Random();
            this.foods = new Food[3];
            this.foodIndex = this.RandomFoodNumber;
            this.GetFoods();
            this.CraeteSnake();
           
        }

        private int RandomFoodNumber => random.Next(0, foods.Length);

        private void CraeteSnake()
        {
            for (int leftX = 1; leftX <= 6; leftX++)
            {
                this.snakeElements.Enqueue(new Point(leftX, 2));
            }

            this.foods[foodIndex].SetRandomPosition(this.snakeElements);
        }

        private void GetFoods()
        {
            this.foods[0] = new FoodHash(wall);
            this.foods[1] = new FoodDollar(wall);
            this.foods[2] = new FoodAsterisk(wall);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = direction.LeftX + snakeHead.LeftX;
            this.nextTopY = direction.TopY + snakeHead.TopY;
        }

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = this.snakeElements.Last();

            GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = this.snakeElements.Any(p => p.LeftX == this.nextLeftX
                                                           && p.TopY == this.nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);

            if (this.wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);

            if(this.foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, currentSnakeHead);
            }

            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(' ');

            return true;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = this.foods[foodIndex].FoodPoints;
            Player.AddPoints(length);

            for (int i = 0; i < length; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                this.GetNextPoint(direction, currentSnakeHead);
            }

            this.foodIndex = this.RandomFoodNumber;
            this.foods[foodIndex].SetRandomPosition(this.snakeElements);
        }
    }
}
