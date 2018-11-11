using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Vehicles
{
    public class Truck : Vehicle
    {
        private const double fuelIncrease = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption,double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += fuelIncrease;
        }
    }
}
