using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface IEngineer :ISpecialisedSoldier
    { 
        ICollection<IRepair> Repairs { get; }
    }
}
