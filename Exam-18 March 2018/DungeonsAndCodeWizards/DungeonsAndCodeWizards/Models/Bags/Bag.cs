using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        private List<Item> items;

        protected Bag(int capacity = 100)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();

        public int Load => this.Items.Sum(i => i.Weight);

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            Item item = null;

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].GetType().Name == name)
                {
                    item = items[i];
                    items.RemoveAt(i);
                    break;
                }
            }

            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            return item;
        }
    }
}
