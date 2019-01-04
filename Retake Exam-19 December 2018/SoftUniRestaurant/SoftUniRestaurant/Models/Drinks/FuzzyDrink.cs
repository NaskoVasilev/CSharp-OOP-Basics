namespace SoftUniRestaurant.Models.Drinks
{
    public class FuzzyDrink : Drink
    {
        private const decimal FuzzyDrinkPrice = 2.50M;

        public FuzzyDrink(string name, int servingSize, string brand) 
            : base(name, servingSize, FuzzyDrinkPrice, brand)
        {
        }
    }
}
