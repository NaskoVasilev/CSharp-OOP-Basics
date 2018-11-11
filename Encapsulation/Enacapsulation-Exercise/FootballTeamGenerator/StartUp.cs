using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    class StartUp
    {
        static List<Team> teams;

        static void Main(string[] args)
        {
            teams = new List<Team>();
            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                string currentTeamName = data[1];

                switch (command)
                {
                    case "Team":
                        AddTeam(currentTeamName);
                        break;
                    case "Add":
                        AddPlayerToTeam(currentTeamName, data);
                        break;
                    case "Remove":
                        string playerName = data[2];
                        ReamovePlayerFromTeam(currentTeamName, playerName);
                        break;
                    case "Rating":
                        PrintRating(currentTeamName);
                        break;
                }
            }
        }

        private static void PrintRating(string teamName)
        {
            Team team = GetTeamByName(teamName);
            if (team == null)
            {
                Console.WriteLine($"Team {teamName} does not exist.");
            }
            else
            {
                Console.WriteLine($"{team.Name} - {team.Rating}");
            }
        }

        private static void ReamovePlayerFromTeam(string teamName, string playerName)
        {
            try
            {
                Team teamToRemoveName = GetTeamByName(teamName);
                if (teamToRemoveName != null)
                {
                    teamToRemoveName.RemovePlayer(playerName);
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static Team GetTeamByName(string teamName)
        {
            return teams.FirstOrDefault(t => t.Name == teamName);
        }

        private static void AddPlayerToTeam(string currentTeamName, string[] data)
        {
            try
            {
                Team team = GetTeamByName(currentTeamName);
                if (team == null)
                {
                    Console.WriteLine($"Team {currentTeamName} does not exist.");
                }
                else
                {
                    string playerName = data[2];
                    int[] stats = new int[5];

                    for (int i = 3; i < 8; i++)
                    {
                        stats[i - 3] = int.Parse(data[i]);
                    }

                    Player player = new Player(playerName, stats);
                    team.AddPlayer(player);
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void AddTeam(string currentTeamName)
        {
            try
            {
                Team team = new Team(currentTeamName);
                teams.Add(team);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}

