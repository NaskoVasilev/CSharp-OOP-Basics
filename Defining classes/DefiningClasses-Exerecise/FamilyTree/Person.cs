using System;
using System.Collections.Generic;
using System.Text;

namespace FamilyTree
{
    class Person
    {
        public string Name { get; set; }
        public string Birthday { get; set; }
        public HashSet<Person> Parents { get; set; }
        public HashSet<Person> Childern { get; set; }

        public Person(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Parents = new HashSet<Person>();
            this.Childern = new HashSet<Person>();
        }
    }
}
