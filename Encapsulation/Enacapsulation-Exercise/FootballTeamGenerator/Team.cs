using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public double Rating
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }

                return Math.Round(this.players.Average(x => x.PlayerAverageSkill));
            }
        }

        public void RemovePlayer(string playerName)
        {
            Player player = this.players.FirstOrDefault(x => x.Name == playerName);
            if(player != null)
            {
                this.players.Remove(player);
            }
            else
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

    }
}
