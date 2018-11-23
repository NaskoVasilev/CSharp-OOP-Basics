using StorageMaster.Factories;
using StorageMaster.Models.Products;
using StorageMaster.Models.Storage;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private Dictionary<string, Stack<Product>> pool;
        private ProductFactory productFactory;
        private Dictionary<string, Storage> storages;
        private StorageFactory storageFactory;
        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.pool = new Dictionary<string, Stack<Product>>();
            productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
            this.storages = new Dictionary<string, Storage>();
        }

        public string AddProduct(string type, double price)
        {
            Product product = productFactory.CreateProduct(type, price);
            string productType = product.GetType().Name;

            if (!pool.ContainsKey(productType))
            {
                pool.Add(productType, new Stack<Product>());
            }

            pool[productType].Push(product);

            return $"Added {productType} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);
            this.storages.Add(name, storage);
            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            this.currentVehicle = this.storages[storageName].GetVehicle(garageSlot);

            return $"Selected {currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;

            foreach (string productName in productNames)
            {
                if (this.currentVehicle.IsFull)
                {
                    break;
                }

                if (!pool.ContainsKey(productName) || pool[productName].Count == 0)
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }

                Product product = pool[productName].Pop();
                this.currentVehicle.LoadProduct(product);
                loadedProductsCount++;
            }

            return $"Loaded {loadedProductsCount}/{productNames.ToArray().Length} products into {this.currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!storages.ContainsKey(sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            if (!storages.ContainsKey(destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            Storage sourceStorage = this.storages[sourceName];
            Storage destinationStorage = this.storages[destinationName];
            Vehicle vehicle = sourceStorage.GetVehicle(sourceGarageSlot);
            int destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages[storageName];
            Vehicle vehicle = storage.GetVehicle(garageSlot);
            int productsInVehicle = vehicle.Trunk.Count;

            int unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = this.storages[storageName];
            Dictionary<string, int> productByCount = new Dictionary<string, int>();

            foreach (Product product in storage.Products)
            {
                string name = product.GetType().Name;

                if (!productByCount.ContainsKey(name))
                {
                    productByCount.Add(name, 0);
                }
                productByCount[name]++;
            }

            string[] productsSatistic = productByCount
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Select(x => $"{x.Key} ({x.Value})")
                .ToArray();

            string[] vehiclesStatistic = storage.Garage
                .Select(v => v == null ? "empty" : v.GetType().Name)
                .ToArray();

            return $"Stock ({storage.Products.Sum(x => x.Weight)}/{storage.Capacity}): [{string.Join(", ", productsSatistic)}]"
                + Environment.NewLine
                + $"Garage: [{string.Join("|", vehiclesStatistic)}]";
        }

        public string GetSummary()
        {
            StringBuilder storagesSummary = new StringBuilder();

            foreach (var storage in this.storages.OrderByDescending(x => x.Value.Products.Sum(p => p.Price)))
            {
                storagesSummary.AppendLine($"{storage.Key}:");
                storagesSummary.AppendLine($"Storage worth: ${storage.Value.Products.Sum(x => x.Price):F2}");
            }

            return storagesSummary.ToString();
        }

    }
}
