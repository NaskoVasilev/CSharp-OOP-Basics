using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    class Pokemon
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Pokemon(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Type}";
        }
    }
}
