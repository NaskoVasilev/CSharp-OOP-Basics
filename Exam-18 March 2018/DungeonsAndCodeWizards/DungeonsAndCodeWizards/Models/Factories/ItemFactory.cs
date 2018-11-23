using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string type)
        {
            switch (type)
            {
                case "ArmorRepairKit":
                    return new ArmorRepairKit();
                case "PoisonPotion":
                    return new PoisonPotion();
                case "HealthPotion":
                    return new HealthPotion();
                default:
                    throw new ArgumentException($"Invalid item \"{ type }\"!");
            }
        }
    }
}
