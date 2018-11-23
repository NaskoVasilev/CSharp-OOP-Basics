using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Enums;
using DungeonsAndCodeWizards.Models.Contracts;
using System;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Cleric : Character, IHealable
    {
        private const double ClericBaseHealth = 50;
        private const double ClericBaseArmor = 25;
        private const double ClericAbilityPoints = 40;
        private const double ClericRestHealMultiplier = 0.5;

        public Cleric(string name, Faction faction)
            : base(name, ClericBaseHealth, ClericBaseArmor, ClericAbilityPoints, new Backpack(), faction)
        {
        }

        public override double RestHealMultiplier => ClericRestHealMultiplier;

        public void Heal(Character character)
        {
            EnsureBothCharactersAreAlive(character);

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;
        }
    }
}
