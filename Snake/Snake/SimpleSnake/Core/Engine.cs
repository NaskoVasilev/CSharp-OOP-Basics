using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Point[] pointsOfDirections;
        private Direction direction;
        private Snake snake;
        private Wall wall;
        private double sleepTime;

        public Engine(Snake snake, Wall wall)
        {
            this.direction = Direction.Right;
            this.pointsOfDirections = new Point[4];
            this.snake = snake;
            this.sleepTime = 100;
            this.wall = wall;
        }

        public void Run()
        {
            this.CreateDirections();

            while (true)
            {
                Player.PrintPlayerInfo();

                if (Console.KeyAvailable)
                {
                    this.GetNextDirection();
                }

                bool isMoving = snake.IsMoving(this.pointsOfDirections[(int)direction]);

                if (!isMoving)
                {
                    this.AskUserForRestart();
                }

                this.sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }
        }

        private void AskUserForRestart()
        {
            int leftX = this.wall.LeftX + 1;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n");

            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game over!");
            Environment.Exit(0);
        }

        private void CreateDirections()
        {
            //Right
            this.pointsOfDirections[0] = new Point(1, 0);
            //Left
            this.pointsOfDirections[1] = new Point(-1, 0);
            //Down
            this.pointsOfDirections[2] = new Point(0, 1);
            //Up
            this.pointsOfDirections[3] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }


    }
}
