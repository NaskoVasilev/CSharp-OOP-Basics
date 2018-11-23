using StorageMaster.Models.Vehicles;
using System;

namespace StorageMaster.Factories
{
    public class VehicleFactory
    {
        Vehicle vehicle;

        public Vehicle CreateVehicle(string type)
        {
            switch(type)
            {
                case "Van":
                    vehicle = new Van();
                    break;
                case "Truck":
                    vehicle = new Truck();
                    break;
                case "Semi":
                    vehicle = new Semi();
                    break;
                default:
                    throw new InvalidOperationException("Invalid vehicle type!");
            }

            return vehicle;
        }
    }
}
