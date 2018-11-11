using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.Animals
{
    class Kitten : Cat
    {
        private const string gender = "Female";

        public Kitten(string name, int age) 
            : base(name, age, gender)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
