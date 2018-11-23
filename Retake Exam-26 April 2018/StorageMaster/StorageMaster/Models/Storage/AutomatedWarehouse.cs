using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storage
{
    public class AutomatedWarehouse : Storage
    {
        private const int AutomatedWarehouseCapacity = 1;
        private const int AutomatedWarehouseGarageSlots = 2;
        private static Vehicle[] dedfaultVehicles = new Vehicle[]
        {
            new Truck()
        };

        public AutomatedWarehouse(string name) 
            : base(name, AutomatedWarehouseCapacity, AutomatedWarehouseGarageSlots, dedfaultVehicles)
        {
        }
    }
}
