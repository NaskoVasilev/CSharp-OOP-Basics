using Society.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Society.Models
{
    public class Citizen : IIdentifiable, IBirthable, IBuyer
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;
        private int food;

        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
            Food = 0;
        }

        public Citizen(string name, int age, string id, string birthdate)
            : this(name, age, id)
        {
            this.Birthdate = birthdate;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int Age
        {
            get { return age; }
            private set { age = value; }
        }

        public string Id
        {
            get { return id; }
            private set { id = value; }
        }

        public string Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        public int Food
        {
            get { return food; }
            private set { food = value; }
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
