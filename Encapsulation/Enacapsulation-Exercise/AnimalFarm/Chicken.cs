using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalFarm
{
    public class Chicken
    {
        private const int MinAge = 0;
        private const int MaxAge = 15;

        private string name;
        private int age;

        public Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Trim() == "")
                {
                    string message = "Name cannot be empty.";
                    ThrowArgummentException(message);
                }
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                if (value < MinAge || value > MaxAge)
                {
                    string message = "Age should be between 0 and 15.";
                    ThrowArgummentException(message);
                }
                this.age = value;
            }
        }

        private void ThrowArgummentException(string message)
        {
            throw new ArgumentException(message);
        }

        public double ProductPerDay
        {
            get
            {
                return this.CalculateProductPerDay();
            }
        }

        private double CalculateProductPerDay()
        {
            switch (this.Age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;
                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;
                default:
                    return 0.75;
            }
        }

        public override string ToString()
        {
            return $"Chicken {Name} (age {Age}) can produce {ProductPerDay} eggs per day.";
        }
    }
}
