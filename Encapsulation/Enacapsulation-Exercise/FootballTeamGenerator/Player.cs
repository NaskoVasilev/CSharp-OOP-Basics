using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    class Player
    {
        private string name;
        private int[] stats;

        public Player(string name, int[] stats)
        {
            Name = name;
            Stats = stats;
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

        public int[] Stats
        {
            get { return stats; }
            private set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] < 0 || value[i] > 100)
                    {
                        string statName = GetStatName(i);
                        throw new ArgumentException($"{statName} should be between 0 and 100.");
                    }
                }
                stats = value;
            }
        }

        public double PlayerAverageSkill
        {
            get
            {
                return this.stats.Average();
            }
        }

        private string GetStatName(int index)
        {
            switch (index)
            {
                case 0:
                    return "Endurance";
                case 1:
                    return "Sprint";
                case 2:
                    return "Dribble";
                case 3:
                    return "Passing";
                case 4:
                    return "Shooting";
            }

            return "";
        }
    }
}
