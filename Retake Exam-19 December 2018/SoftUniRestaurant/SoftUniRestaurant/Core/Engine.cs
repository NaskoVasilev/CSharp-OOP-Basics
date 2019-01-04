using SoftUniRestaurant.IO.Contracts;
using System;
using System.Reflection;

namespace SoftUniRestaurant.Core
{
    public class Engine
    {
        private RestaurantController restaurantController;
        private IWriter writer;
        private IReader reader;

        public Engine(RestaurantController restaurantController, IWriter writer, IReader reader)
        {
            this.restaurantController = restaurantController;
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            while (true)
            {
                string input = reader.ReadLine();
                if(input == "END")
                {
                    break;
                }

                string[] data = input.Split();

                try
                {
                    ProcessCommand(data);
                }
                catch (ArgumentException ex)
                {
                    writer.AppendLine(ex.Message);
                }
                catch(TargetInvocationException ex)
                {
                    writer.AppendLine(ex.InnerException.Message);
                }
            }

            writer.AppendLine(this.restaurantController.GetSummary());
            writer.WriteAllLines();
        }

        private void ProcessCommand(string[] data)
        {
            string commandType = data[0];
            string name = "";
            string type = "";
            int tableNumber = 0;
            string result = "";

            switch(commandType)
            {
                case "AddFood":
                    type = data[1];
                    name = data[2];
                    decimal price = decimal.Parse(data[3]);
                    result = this.restaurantController.AddFood(type, name, price);
                    break;
                case "AddDrink":
                    type = data[1];
                    name = data[2];
                    int servingSize = int.Parse(data[3]);
                    string brand = data[4];
                    result = this.restaurantController.AddDrink(type, name, servingSize, brand);
                    break;
                case "AddTable":
                    type = data[1];
                    tableNumber = int.Parse(data[2]);
                    int capacity = int.Parse(data[3]);
                    result = this.restaurantController.AddTable(type, tableNumber, capacity);
                    break;
                case "ReserveTable":
                    int numberOfPeople = int.Parse(data[1]);
                    result = this.restaurantController.ReserveTable(numberOfPeople);
                    break;
                case "OrderFood":
                    tableNumber = int.Parse(data[1]);
                    string foodName = data[2];
                    result = this.restaurantController.OrderFood(tableNumber, foodName);
                    break;
                case "OrderDrink":
                    tableNumber = int.Parse(data[1]);
                    string drinkName = data[2];
                    string drinkBrand = data[3];
                    result = this.restaurantController.OrderDrink(tableNumber, drinkName, drinkBrand);
                    break;
                case "LeaveTable":
                    tableNumber = int.Parse(data[1]);
                    result = this.restaurantController.LeaveTable(tableNumber);
                    break;
                case "GetFreeTablesInfo":
                    result = this.restaurantController.GetFreeTablesInfo();
                    break;
                case "GetOccupiedTablesInfo":
                    result = this.restaurantController.GetOccupiedTablesInfo();
                    break;
            }

            writer.AppendLine(result);
        }
    }
}
