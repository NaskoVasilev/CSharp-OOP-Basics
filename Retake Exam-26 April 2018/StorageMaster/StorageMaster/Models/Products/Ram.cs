namespace StorageMaster.Models.Products
{
    public class Ram : Product
    {
        private const double RamWeight = 0.1;

        public Ram(double price) : base(price, RamWeight)
        {
        }
    }
}
