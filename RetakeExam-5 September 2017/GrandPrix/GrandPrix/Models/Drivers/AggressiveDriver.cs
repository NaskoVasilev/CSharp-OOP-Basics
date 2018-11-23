
public class AggressiveDriver : Driver
{
    private const double fuelConsumptionPerKm = 2.7;
    private const double speedMultiplier = 1.3;

    public AggressiveDriver(string name, Car car)
        : base(name, car, fuelConsumptionPerKm)
    {
    }

    public override double Speed => base.Speed * speedMultiplier;
}

