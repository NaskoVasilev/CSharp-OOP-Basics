namespace SoftUniRestaurant.Models.Drinks
{
    public class Alcohol : Drink
    {
        private const decimal AlcoholPrice = 3.50M;

        public Alcohol(string name, int servingSize, string brand) 
            : base(name, servingSize, AlcoholPrice, brand)
        {
        }
    }
}
