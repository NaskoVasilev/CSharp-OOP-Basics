using System.Collections.Generic;
using MilitaryElite.Contracts;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public ICollection<IPrivate> Privates { get; private set; }

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append("\nPrivates:");

            foreach (var privateSoldier in this.Privates)
            {
                sb.Append("\n  " + privateSoldier.ToString());
            }

            return sb.ToString();
        }
    }
}
