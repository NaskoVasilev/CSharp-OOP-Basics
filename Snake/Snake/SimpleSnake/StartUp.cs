namespace SimpleSnake
{
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using System;
    using Utilities;

    public class StartUp
    {
        public static Wall wall;

        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            wall = new Wall(60, 20);

            Snake snake = new Snake(wall);

            Engine engine = new Engine(snake, wall);
            engine.Run();

        }
    }
}
