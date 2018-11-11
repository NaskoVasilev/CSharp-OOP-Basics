using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
    }
}
