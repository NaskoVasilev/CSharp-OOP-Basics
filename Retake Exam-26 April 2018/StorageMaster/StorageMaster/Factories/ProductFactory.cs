using StorageMaster.Models.Products;
using System;

namespace StorageMaster.Factories
{
    public class ProductFactory
    {
        private Product product;

        public Product CreateProduct(string type,double price)
        {
            type = type.ToLower();

            switch(type)
            {
                case "gpu":
                    this.product = new Gpu(price);
                    break;
                case "harddrive":
                    this.product = new HardDrive(price);
                    break;
                case "ram":
                    this.product = new Ram(price);
                    break;
                case "solidstatedrive":
                    this.product = new SolidStateDrive(price);
                    break;
                default:
                    throw new InvalidOperationException("Invalid product type!");
            }

            return product;
        }
    }
}
