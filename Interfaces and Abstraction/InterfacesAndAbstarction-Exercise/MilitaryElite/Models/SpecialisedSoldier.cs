using MilitaryElite.Contracts;
using MilitaryElite.Enums;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public Corps Corps { get; set; }

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

    }
}
