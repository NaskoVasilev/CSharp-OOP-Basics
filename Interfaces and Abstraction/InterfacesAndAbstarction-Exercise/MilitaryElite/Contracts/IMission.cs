using MilitaryElite.Enums;

namespace MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }

        States State { get; set; }

        void CompleteMission();
    }
}
