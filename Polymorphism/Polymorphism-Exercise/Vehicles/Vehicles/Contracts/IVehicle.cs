namespace Vehicles
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        bool VehicleIsEmpty { get; set; }

        double TankCapacity { get; }

        void Drive(double distance);

        void Refuel(double fuel);
    }
}
