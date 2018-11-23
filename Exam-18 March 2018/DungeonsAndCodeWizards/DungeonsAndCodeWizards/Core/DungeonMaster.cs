using DungeonsAndCodeWizards.Models;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Enums;
using DungeonsAndCodeWizards.Models.Factories;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private Dictionary<string, Character> characters;
        private CharacterFactory characterFactory;
        Stack<Item> pool;
        ItemFactory itemFactory;
        private int rounds;

        public DungeonMaster()
        {
            this.characters = new Dictionary<string, Character>();
            this.characterFactory = new CharacterFactory();
            pool = new Stack<Item>();
            itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            string factionAsString = args[0];
            string characterType = args[1];
            string name = args[2];

            Character newCharacter = characterFactory.CreateCharacter(factionAsString, characterType, name);
            characters.Add(newCharacter.Name, newCharacter);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemType = args[0];

            Item item = itemFactory.CreateItem(itemType);
            this.pool.Push(item);

            return $"{itemType} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            this.CharacterExists(characterName);

            if (this.pool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Character character = this.characters[characterName];
            Item item = this.pool.Pop();
            character.Bag.AddItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemType = args[1];
            this.CharacterExists(characterName);

            Character character = this.characters[characterName];
            Item item = character.Bag.GetItem(itemType);
            character.UseItem(item);

            return $"{character.Name} used {itemType}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            this.CharacterExists(giverName);
            this.CharacterExists(receiverName);

            Character giver = this.characters[giverName];
            Character receiver = this.characters[receiverName];
            Item item = giver.Bag.GetItem(itemName);
            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            this.CharacterExists(giverName);
            this.CharacterExists(receiverName);

            Character giver = this.characters[giverName];
            Character receiver = this.characters[receiverName];
            Item item = giver.Bag.GetItem(itemName);
            giver.GiveCharacterItem(item, receiver);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder stats = new StringBuilder();
            Character[] finalCharacters = this.characters
                .Select(x => x.Value)
                .OrderByDescending(x => x.IsAlive)
                .ThenByDescending(x => x.Health)
                .ToArray();

            foreach (var character in finalCharacters)
            {
                string line = string.Format("{0} - HP: {1}/{2}, AP: {3}/{4}, Status: {5}",
                    character.Name,
                    character.Health,
                    character.BaseHealth,
                    character.Armor,
                    character.BaseArmor,
                    (character.IsAlive ? "Alive" : "Dead"));

                stats.AppendLine(line);
            }

            return stats.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            this.CharacterExists(attackerName);
            this.CharacterExists(receiverName);

            Character attacker = this.characters[attackerName];
            Character receiver = this.characters[receiverName];

            if (attacker is Warrior warrior)
            {
                warrior.Attack(receiver);
                string output = string.Format("{0} attacks {1} for {2} hit points! {1} has {3}/{4} HP and {5}/{6} AP left!",
                    attackerName,
                    receiverName,
                    attacker.AbilityPoints,
                    receiver.Health,
                    receiver.BaseHealth,
                    receiver.Armor,
                    receiver.BaseArmor);

                if (receiver.IsAlive == false)
                {
                    output += $"\n{receiver.Name} is dead!";
                }

                return output;
            }
            else
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            this.CharacterExists(healerName);
            this.CharacterExists(healingReceiverName);

            Character healer = this.characters[healerName];
            Character receiver = this.characters[healingReceiverName];

            if (healer is Cleric currentHealer)
            {
                currentHealer.Heal(receiver);
                string output = string.Format("{0} heals {1} for {2}! {1} has {3} health now!",
                    healer.Name,
                    receiver.Name,
                    healer.AbilityPoints,
                    receiver.Health);

                return output;
            }
            else
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }
        }

        public string EndTurn(string[] args)
        {
            StringBuilder output = new StringBuilder();

            foreach (var character in this.characters.Select(x => x.Value).Where(c => c.IsAlive))
            {
                double healthBeforeRest = character.Health;
                character.Rest();
                output.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }

            if (this.characters.Count(x => x.Value.IsAlive) <= 1)
            {
                this.rounds++;
            }

            return output.ToString().Trim();
        }

        public bool IsGameOver()
        {
            if (this.rounds > 1)
            {
                return true;
            }

            return false;
        }

        private void CharacterExists(string name)
        {
            if (!characters.ContainsKey(name))
            {
                throw new ArgumentException($"Character {name} not found!");
            }
        }


    }
}
