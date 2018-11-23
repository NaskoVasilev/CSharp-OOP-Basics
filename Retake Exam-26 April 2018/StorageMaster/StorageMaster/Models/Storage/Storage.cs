using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Models.Storage
{
    public abstract class Storage
    {
        private Vehicle[] garage;

        private List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.products = new List<Product>();
            this.garage = new Vehicle[this.GarageSlots];

            this.FillGarageWithVehicles(vehicles);
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int GarageSlots { get; private set; }

        public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(this.garage);

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public bool IsFull => this.products.Sum(x => x.Weight) >= this.Capacity;

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            Vehicle targetVehicle = this.garage[garageSlot];

            if (targetVehicle == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return targetVehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);
            int targetGarageIndex = Array.IndexOf(deliveryLocation.garage, null);

            if (targetGarageIndex == -1)
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[garageSlot] = null;
            deliveryLocation.garage[targetGarageIndex] = vehicle;
            return targetGarageIndex;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            int unloadedProductsCount = 0;
            Vehicle vehicle = this.GetVehicle(garageSlot);

            while (!vehicle.IsEmpty && !this.IsFull)
            {
                Product product = vehicle.Unload();
                this.products.Add(product);
                unloadedProductsCount++;
            }

            return unloadedProductsCount;
        }

        private void FillGarageWithVehicles(IEnumerable<Vehicle> vehicles)
        {
            int index = 0;

            foreach (Vehicle vehicle in vehicles)
            {
                this.garage[index++] = vehicle;
            }
        }

    }
}
