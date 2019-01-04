namespace SoftUniRestaurant.IO
{
    public static class Messages
    {
        public const string NameValidation = "Name cannot be null or white space!";

        public const string ServingSizeValidation = "Serving size cannot be less or equal to zero";

        public const string PriceValidation = "Price cannot be less or equal to zero!";

        public const string BrandValidation = "Brand cannot be null or white space!";

        public const string CapacityValidation = "Capacity has to be greater than 0";

        public const string NumberofPeopleValidation = "Cannot place zero or less people!";

        public const string FreeTableInfo = "Table: {0}\nType: {1}\nCapacity: {2}\nPrice per Person: {3}";

        public const string OccupiedTableInfo = "Table: {0}\nType: {1}\nNumber of people: {2}";

        public const string SuccessfulyAddedFood = "Added {0} ({1}) with price {2:f2} to the pool";

        public const string SuccessfulyAddedDrink = "Added {0} ({1}) to the drink pool";

        public const string SuccessfulyAddedTable = "Added table number {0} in the restaurant";

        public const string NoAvailableTable = "No available table for {0} people";

        public const string ReserveTable = "Table {0} has been reserved for {1} people";

        public const string TableNotFound = "Could not find table with {0}";

        public const string FoodNotFound = "No {0} in the menu";

        public const string SuccessfullyOrderFood = "Table {0} ordered {1}";

        public const string DrinkNotFound = "There is no {0} {1} available";

        public const string SuccessfullyOrderDrink = "Table {0} ordered {1} {2}";

        public const string LeaveTable = "Table: {0}\nBill: {1:F2}";


        public const string Summary = "Total income: {0:f2}lv";
    }
}
