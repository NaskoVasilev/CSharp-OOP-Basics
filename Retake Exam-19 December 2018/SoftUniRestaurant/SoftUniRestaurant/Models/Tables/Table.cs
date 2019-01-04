using SoftUniRestaurant.IO;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;
        private List<IFood> foodOrders;
        private List<IDrink> drinkOrders;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
            this.IsReserved = false;
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Messages.CapacityValidation);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get { return this.numberOfPeople; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Messages.NumberofPeopleValidation);
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public decimal Price => this.PricePerPerson * this.NumberOfPeople;

        public bool IsReserved { get; private set; }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            return this.drinkOrders.Sum(d => d.Price) + this.foodOrders.Sum(f => f.Price) + this.Price;
        }

        public void Clear()
        {
            this.drinkOrders.Clear();
            this.foodOrders.Clear();
            this.numberOfPeople = 0;
            this.IsReserved = false;
        }

        public string GetFreeTableInfo()
        {
            return string.Format(Messages.FreeTableInfo,
                this.TableNumber,
                this.GetType().Name,
                this.Capacity,
                this.PricePerPerson);
        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(Messages.OccupiedTableInfo,
                this.TableNumber,
                this.GetType().Name,
                this.NumberOfPeople));

            if(this.foodOrders.Count == 0)
            {
                sb.AppendLine("Food orders: None");
            }
            else
            {
                sb.AppendLine($"Food orders: {foodOrders.Count}");
                sb.AppendLine(string.Join(Environment.NewLine, this.foodOrders));
            }


            if (this.drinkOrders.Count == 0)
            {
                sb.AppendLine("Drink orders: None");
            }
            else
            {
                sb.AppendLine($"Drink orders: {drinkOrders.Count}");
                sb.AppendLine(string.Join(Environment.NewLine, this.drinkOrders));
            }

            return sb.ToString().Trim();
        }
    }
}
