namespace SoftUniRestaurant.Core
{
    using Models.Drinks.Factory;
    using Models.Foods.Factory;
    using Models.Tables.Factory;
    using IO;
    using Models.Drinks.Contracts;
    using Models.Foods.Contracts;
    using Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RestaurantController
    {
        private FoodFactory foodFactory;
        private TableFactory tableFactory;
        private DrinkFactory drinkFactory;
        private List<IFood> menu;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome;

        public RestaurantController()
        {
            this.foodFactory = new FoodFactory();
            this.tableFactory = new TableFactory();
            this.drinkFactory = new DrinkFactory();
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddFood(string type, string name, decimal price)
        {
            IFood food = foodFactory.CreateFood(type, name, price);
            this.menu.Add(food);

            return string.Format(Messages.SuccessfulyAddedFood, food.Name, type, food.Price);
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink = drinkFactory.CreateDrink(type, name, servingSize, brand);
            this.drinks.Add(drink);

            return string.Format(Messages.SuccessfulyAddedDrink, drink.Name, drink.Brand);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = tableFactory.CreateTable(type, tableNumber, capacity);
            this.tables.Add(table);

            return string.Format(Messages.SuccessfulyAddedTable, table.TableNumber);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);

            if (table == null)
            {
                string message = string.Format(Messages.NoAvailableTable, numberOfPeople);
                return message;
            }

            table.Reserve(numberOfPeople);
            return string.Format(Messages.ReserveTable, table.TableNumber, numberOfPeople);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = GetTableByNumer(tableNumber);
            if (table == null)
            {
                string message = string.Format(Messages.TableNotFound, tableNumber);
                return message;
            }

            IFood food = GetFoodByName(foodName);
            if (food == null)
            {
                string message = string.Format(Messages.FoodNotFound, foodName);
                return message;
            }

            table.OrderFood(food);
            return string.Format(Messages.SuccessfullyOrderFood, tableNumber, foodName);
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = GetTableByNumer(tableNumber);
            if (table == null)
            {
                string message = string.Format(Messages.TableNotFound, tableNumber);
                return message;
            }

            IDrink drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
            if (drink == null)
            {
                string message = string.Format(Messages.DrinkNotFound, drinkName, drinkBrand);
                return message;
            }

            table.OrderDrink(drink);
            return string.Format(Messages.SuccessfullyOrderDrink, tableNumber, drinkName, drinkBrand);
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = GetTableByNumer(tableNumber);
            decimal bill = table.GetBill();
            this.totalIncome += bill;
            table.Clear();

            return string.Format(Messages.LeaveTable, table.TableNumber, bill);
        }

        public string GetFreeTablesInfo()
        {
            return string.Join(Environment.NewLine, this.tables
                .Where(t => t.IsReserved == false)
                .Select(t => t.GetFreeTableInfo()));
        }

        public string GetOccupiedTablesInfo()
        {
            return string.Join(Environment.NewLine, this.tables
                .Where(t => t.IsReserved)
                .Select(t => t.GetOccupiedTableInfo()));
        }

        public string GetSummary()
        {
            return string.Format(Messages.Summary, totalIncome);
        }

        private ITable GetTableByNumer(int tableNumber)
        {
            return this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
        }

        private IFood GetFoodByName(string name)
        {
            return this.menu.FirstOrDefault(x => x.Name == name);
        }

        private IDrink GetDrinkByName(string name)
        {
            return this.drinks.FirstOrDefault(x => x.Name == name);
        }
    }
}
