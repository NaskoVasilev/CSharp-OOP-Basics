using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    class Person
    {
        public string Name { get; set; }
        public Company Comapny { get; set; }
        public Car Car { get; set; }
        public List<Parent> Parents { get; set; }
        public List<Child> Childern { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public Person(string name)
        {
            this.Name = name;
            this.Parents = new List<Parent>();
            this.Pokemons = new List<Pokemon>();
            this.Childern = new List<Child>();
        }
    }
}
