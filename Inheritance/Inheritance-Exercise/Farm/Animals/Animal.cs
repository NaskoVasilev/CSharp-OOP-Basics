using Farm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.Animals
{
    public class Animal : ISoundProducable
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            }
        }

        public string Gender
        {
            get { return gender; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                gender = value;
            }
        }

        public virtual void ProduceSound()
        {
        }

        public override string ToString()
        {
            string output = "";
            output += $"{this.GetType().Name}\n";
            output += $"{this.Name} {this.Age} {this.Gender}";
            return output;
        }

    }
}
