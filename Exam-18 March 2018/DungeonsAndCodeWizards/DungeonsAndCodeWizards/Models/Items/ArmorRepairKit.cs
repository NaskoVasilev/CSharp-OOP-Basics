using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class ArmorRepairKit : Item
    {
        private const int InitialWeight = 10;

        public ArmorRepairKit() : base(InitialWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Armor = character.BaseArmor;
        }
    }
}
