using System;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Team team = new Team("My team");
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(data[0], data[1], int.Parse(data[2]), decimal.Parse(data[3]));
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
