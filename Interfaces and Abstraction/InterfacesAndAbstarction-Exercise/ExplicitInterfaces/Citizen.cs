using ExplicitInterfaces.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    public class Citizen : IPerson, IResident
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Country { get; private set; }

        public Citizen(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }

        string IPerson.GetName()
        {
            return this.Name;
        }
    }
}
