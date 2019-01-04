using SoftUniRestaurant.Models.Tables.Contracts;
using System;

namespace SoftUniRestaurant.Models.Tables.Factory
{
    public class TableFactory
    {
        internal ITable firstOrDefault;

        public ITable CreateTable(string type, int tableNumber, int capacity)
        {
            switch (type)
            {
                case "Inside":
                    return new InsideTable(tableNumber, capacity);
                case "Outside":
                    return new OutsideTable(tableNumber, capacity);
                default:
                    throw new ArgumentException("Invalid type!");
            }
        }

        //Reflection is not allowed
        //public ITable CreateTable(string type, int tableNumber, int capacity)
        //{
        //    Type tableType = Assembly.GetExecutingAssembly()
        //        .GetTypes()
        //        .FirstOrDefault(t => t.Name == type + "Table");

        //    return (ITable)Activator.CreateInstance(tableType, tableNumber, capacity);
        //}
    }
}
