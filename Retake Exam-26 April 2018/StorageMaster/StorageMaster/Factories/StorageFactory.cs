using StorageMaster.Models.Storage;
using System;

namespace StorageMaster.Factories
{
    public class StorageFactory
    {
        Storage storage;

        public Storage CreateStorage(string type, string name)
        {
            switch (type)
            {
                case "AutomatedWarehouse":
                    storage = new AutomatedWarehouse(name);
                    break;
                case "Warehouse":
                    storage = new Warehouse(name);
                    break;
                case "DistributionCenter":
                    storage = new DistributionCenter(name);
                    break;
                default:
                    throw new InvalidOperationException("Invalid storage type!");
            }

            return storage;
        }
    }
}
