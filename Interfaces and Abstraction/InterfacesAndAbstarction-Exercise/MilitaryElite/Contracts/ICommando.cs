using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        ICollection<IMission> Missions { get; }
    }
}
