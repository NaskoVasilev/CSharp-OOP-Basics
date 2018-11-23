using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Contracts
{
    public interface IAttackable
    {
       void Attack(Character character);
    }
}
