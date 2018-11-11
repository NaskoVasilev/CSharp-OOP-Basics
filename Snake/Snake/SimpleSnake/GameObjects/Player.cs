using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public static class Player
    {
        private static int playerPoints;

        public static void AddPoints(int points)
        {
            playerPoints += points;
        }

        public static void PrintPlayerInfo()
        {
            Console.SetCursorPosition(StartUp.wall.LeftX + 5, 0);
            Console.Write("Player points: {0}", playerPoints);
            Console.SetCursorPosition(StartUp.wall.LeftX + 5, 2);
            Console.Write("Player level: {0}", (playerPoints / 10) + 1);
        }
    }
}
