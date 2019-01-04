using SoftUniRestaurant.IO;
using SoftUniRestaurant.Models.Drinks.Contracts;
using System;

namespace SoftUniRestaurant.Models.Drinks
{
    public abstract class Drink : IDrink
    {
        private string name;
        private int servingSize;
        private decimal price;
        private string brand;

        protected Drink(string name, int servingSize, decimal price, string brand)
        {
            this.Name = name;
            this.ServingSize = servingSize;
            this.Price = price;
            this.Brand = brand;
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
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Messages.PriceValidation);
                }
                price = value;
            }
        }

        public string Brand
        {
            get { return brand; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Messages.BrandValidation);
                }
                brand = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Brand} - {this.ServingSize}ml - {this.Price:F2}lv";
        }
    }
}
