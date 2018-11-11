using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] room;
        static int[] playerPosition = new int[2];
        static int[] enemyPosition = new int[2];

        static void Main()
        {
            int roomSize = int.Parse(Console.ReadLine());
            room = new char[roomSize][];
            FillRoom(roomSize);
            GetPlayerAndEnemyPosition();
            var directions = Console.ReadLine().ToCharArray();

            for (int i = 0; i < directions.Length; i++)
            {
                MoveEnemies();

                int indexOfD = Array.IndexOf(room[playerPosition[0]], 'd');
                int indexOfB = Array.IndexOf(room[playerPosition[0]], 'b');
                bool playerIsKilledByD = indexOfD != -1 && playerPosition[1] < indexOfD;
                bool playerIsKilledByB = indexOfB != -1 && playerPosition[1] > indexOfB;

                if (playerIsKilledByD || playerIsKilledByB)
                {
                    room[playerPosition[0]][playerPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {playerPosition[0]}, {playerPosition[1]}");
                    PrintMatrix();
                    return;
                }

                room[playerPosition[0]][playerPosition[1]] = '.';
                MovePlayer(directions[i]);

                if (enemyPosition[0] == playerPosition[0])
                {
                    room[enemyPosition[0]][enemyPosition[1]] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    PrintMatrix();
                    return;
                }
            }
        }

        private static void PrintMatrix()
        {
            foreach (var row in room)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void MovePlayer(char direction)
        {
            switch (direction)
            {
                case 'U':
                    playerPosition[0]--;
                    break;
                case 'D':
                    playerPosition[0]++;
                    break;
                case 'L':
                    playerPosition[1]--;
                    break;
                case 'R':
                    playerPosition[1]++;
                    break;
                default:
                    break;
            }
            room[playerPosition[0]][playerPosition[1]] = 'S';
        }

        private static void MoveEnemies()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (IsInside(row, col + 1))
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (IsInside(row, col - 1))
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < room.Length
                && col >= 0 && col < room[row].Length;
        }

        private static void FillRoom(int roomSize)
        {
            for (int row = 0; row < roomSize; row++)
            {
                room[row] = Console.ReadLine().ToCharArray();
            }
        }

        private static void GetPlayerAndEnemyPosition()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = col;
                    }
                    else if (room[row][col] == 'N')
                    {
                        enemyPosition[0] = row;
                        enemyPosition[1] = col;
                    }
                }
            }
        }
    }
}
