using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Enums;
using DungeonsAndCodeWizards.Models.Items;
using System;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character
    {
        private const double defaultRestHealMultiplier = 0.2;
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints,
            Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
            this.RestHealMultiplier = defaultRestHealMultiplier;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health
        {
            get => this.health;
            set
            {
                if (value <= 0)
                {
                    this.health = 0;
                    this.IsAlive = false;
                }
                else if (value > this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }
                else
                {
                    this.health = value;
                }
            }
        }

        public double BaseArmor { get; private set; }

        public double Armor
        {
            get => this.armor;
            set
            {
                if (value < 0)
                {
                    this.armor = 0;
                }
                else if (value > this.BaseArmor)
                {
                    this.armor = this.BaseArmor;
                }
                else
                {
                    this.armor = value;
                }
            }
        }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public Faction Faction { get; private set; }

        public bool IsAlive { get; set; }

        public virtual double RestHealMultiplier { get; private set; }

        public void TakeDamage(double hitPoints)
        {
            EnsureCharacterIsAlive();

            if (this.Armor >= hitPoints)
            {
                this.Armor -= hitPoints;
            }
            else
            {
                hitPoints -= this.Armor;
                this.Armor = 0;
                this.Health -= hitPoints;
            }
        }

        public void Rest()
        {
            EnsureCharacterIsAlive();
            this.Health += this.BaseHealth * this.RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            EnsureCharacterIsAlive();
            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            EnsureBothCharactersAreAlive(character);
            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            EnsureBothCharactersAreAlive(character);
            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            EnsureCharacterIsAlive();
            this.Bag.AddItem(item);
        }

        private void EnsureCharacterIsAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        protected void EnsureBothCharactersAreAlive(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
