using System.Collections.Generic;
using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public ICollection<IMission> Missions { get; private set; }

        public Commando(string id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<IMission>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($"\nCorps: {this.Corps}");
            sb.Append("\nMissions:");

            foreach (var mission in this.Missions)
            {
                sb.Append("\n  " + mission.ToString());
            }

            return sb.ToString();
        }
    }
}
