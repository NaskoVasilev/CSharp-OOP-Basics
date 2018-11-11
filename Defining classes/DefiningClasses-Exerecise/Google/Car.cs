using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    class Car
    {
        public string Name { get; set; }
        public string Speed { get; set; }

        public Car(string name, string speed)
        {
            this.Name = name;
            this.Speed = speed;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Speed}";
        }
    }
}
