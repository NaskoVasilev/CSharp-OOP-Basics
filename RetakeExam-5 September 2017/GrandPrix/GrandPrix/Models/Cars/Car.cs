using System;

public class Car
{
    private const double maxFuelAmount = 160;
    private TyreFactory tyreFactory;

    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        Hp = hp;
        FuelAmount = fuelAmount;
        Tyre = tyre;
        this.tyreFactory = new TyreFactory();
    }

    public int Hp { get; }

    public double FuelAmount
    {
        get => this.fuelAmount;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ErrorMessages.OutOfFuel);
            }

            this.fuelAmount = Math.Min(value, maxFuelAmount);
        }
    }

    public Tyre Tyre { get; private set; }

    public void ReduceFuelAmount(int trackLength, double driverFuelConsumptionPerKm)
    {
        this.FuelAmount -= trackLength * driverFuelConsumptionPerKm;

    }
    public void Refuel(double fuelAmount)
    {
        this.FuelAmount += fuelAmount;
    }

    public void ChangeTyre(string tyreType, double hardness, double grip)
    {
        Tyre tyre = this.tyreFactory.CreateTyre(tyreType, hardness, grip);

        this.Tyre = tyre;
    }
}

