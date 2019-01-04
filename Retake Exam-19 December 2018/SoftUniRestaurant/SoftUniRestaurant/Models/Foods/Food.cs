using SoftUniRestaurant.IO;
using SoftUniRestaurant.Models.Foods.Contracts;
using System;

namespace SoftUniRestaurant.Models.Foods
{
    public abstract class Food : IFood
    {
        private string name;
        private int servingSize;
        private decimal price;

        protected Food(string name, int servingSize, decimal price)
        {
            this.Name = name;
            this.ServingSize = servingSize;
            this.Price = price;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Messages.NameValidation);
                }
                name = value;
            }
        }

        public int ServingSize
        {
            get { return servingSize; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Messages.ServingSizeValidation);
                }
                servingSize = value;
            }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Messages.PriceValidation);
                }
                price = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.ServingSize}g - {this.Price:F2}";
        }
    }
}
