using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        ICollection<IPrivate> Privates { get; }
    }
}
