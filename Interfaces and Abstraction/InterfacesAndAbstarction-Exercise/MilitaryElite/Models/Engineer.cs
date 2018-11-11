using MilitaryElite.Enums;
using MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public ICollection<IRepair> Repairs { get; private set; }

        public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<IRepair>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($"\nCorps: {this.Corps}");
            sb.Append("\nRepairs:");

            foreach (var repair in this.Repairs)
            {
                sb.Append("\n  " + repair.ToString());
            }

            return sb.ToString();
        }
    }
}
