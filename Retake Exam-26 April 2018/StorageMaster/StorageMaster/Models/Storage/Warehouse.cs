using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storage
{
    public class Warehouse : Storage
    {
        private const int WareHouseCapacity = 10;
        private const int WareHouseGarageSlots = 10;
        private static Vehicle[] defaultVehicles = new Vehicle[]
        {
            new Semi(),
            new Semi(),
            new Semi()
        };

        public Warehouse(string name) 
            : base(name, WareHouseCapacity, WareHouseGarageSlots, defaultVehicles)
        {
        }
    }
}
