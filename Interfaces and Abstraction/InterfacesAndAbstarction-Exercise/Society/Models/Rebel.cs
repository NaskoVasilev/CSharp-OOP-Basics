using Society.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Society.Models
{
    public class Rebel : IBuyer
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Group { get; private set; }

        public int Food { get; private set; }

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = 0;
        }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
