using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Vehicles
{

    public class Car : Vehicle
    {
        private const double fuelIncrease = 0.9;

        public Car(double fuelQuantity, double fuelConsumption,double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += fuelIncrease;
        }
    }
}
