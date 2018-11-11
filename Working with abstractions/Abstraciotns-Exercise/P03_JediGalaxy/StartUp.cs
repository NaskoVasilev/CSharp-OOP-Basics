using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class StartUp
    {
        static void Main()
        {
            int[] dimensions = ParseInputToArray(Console.ReadLine());
            int rows = dimensions[0];
            int cols = dimensions[1];

            Board board = new Board(rows, cols);

            string command = Console.ReadLine();
            long sum = 0;

            while (command != "Let the Force be with you")
            {
                int[] playerCoordinates = ParseInputToArray(command);
                int[] evilCoordinates = ParseInputToArray(Console.ReadLine());

                Player evil = new Player(evilCoordinates[0], evilCoordinates[1]);

                while (evil.Row >= 0 && evil.Col >= 0)
                {
                    if (board.IsInside(evil.Row, evil.Col))
                    {
                        board.Matrix[evil.Row, evil.Col] = 0;
                    }
                    evil.Row--;
                    evil.Col--;
                }

                Player player = new Player(playerCoordinates[0], playerCoordinates[1]);

                while (player.Row >= 0 && player.Col < board.Matrix.GetLength(1))
                {
                    if (board.IsInside(player.Row, player.Col))
                    {
                        sum += board.Matrix[player.Row, player.Col];
                    }

                    player.Col++;
                    player.Row--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        private static int[] ParseInputToArray(string data)
        {
            return data
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
