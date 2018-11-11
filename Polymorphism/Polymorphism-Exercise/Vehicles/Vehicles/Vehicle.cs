using System;
using Vehicles.Vehicles;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private const double busFuelIncrease = 1.4;

        public double FuelQuantity { get; protected set; }

        public double FuelConsumption { get; protected set; }

        public double TankCapacity { get; protected set; }

        public bool VehicleIsEmpty { get; set; }

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                this.FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public void Drive(double distance)
        {
            double neededFuel = 0;
            if(this is Bus  && !this.VehicleIsEmpty)
            {
                neededFuel = distance * (this.FuelConsumption + busFuelIncrease);
            }
            else
            {
                neededFuel = distance * this.FuelConsumption;
            }

            if (neededFuel > this.FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= neededFuel;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }

        public void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + fuel > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            if (this is Truck)
            {
                this.FuelQuantity += fuel * 0.95;
            }
            else
            {
                this.FuelQuantity += fuel;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
