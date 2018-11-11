using MilitaryElite.Enums;

namespace MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; set; }
    }
}
