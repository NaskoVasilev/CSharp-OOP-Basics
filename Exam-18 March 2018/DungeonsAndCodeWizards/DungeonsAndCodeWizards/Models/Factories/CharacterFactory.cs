using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Enums;
using System;

namespace DungeonsAndCodeWizards.Models.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string factionAsString, string type, string name)
        {
            bool isValidFaction = Enum.TryParse(factionAsString, out Faction faction);

            if (!isValidFaction)
            {
                throw new ArgumentException($"Invalid faction \"{ factionAsString }\"!");
            }

            switch (type)
            {
                case "Warrior":
                    return new Warrior(name, faction);
                case "Cleric":
                    return new Cleric(name, faction);
                default:
                    throw new ArgumentException($"Invalid character type \"{type}\"!");
            }
        }
    }
}
