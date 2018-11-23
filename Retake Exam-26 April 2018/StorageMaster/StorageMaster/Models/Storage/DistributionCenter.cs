using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storage
{
    class DistributionCenter : Storage
    {
        private const int DistributionCenterCapacity = 2;
        private const int DistributionCenterGarageSlots = 5;
        private static Vehicle[] defaultVehicles = new Vehicle[]
        {
            new Van(),
            new Van(),
            new Van()
        };

        public DistributionCenter(string name)
            : base(name, DistributionCenterCapacity, DistributionCenterGarageSlots, defaultVehicles)
        {
        }
    }
}
