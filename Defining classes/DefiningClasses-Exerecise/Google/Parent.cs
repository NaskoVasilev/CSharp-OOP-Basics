using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    class Parent
    {
        public string Name { get; set; }
        public string Birthday { get; set; }

        public Parent(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Birthday}";
        }
    }
}
