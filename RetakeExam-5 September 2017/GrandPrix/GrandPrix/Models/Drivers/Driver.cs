using System.Collections.Generic;

public abstract class Driver
{
    private const int needeTimeToGoToBox = 20;

    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.TotalTime = 0;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.IsRacing = true;
    }

    public string Name { get; }

    public string FailureReason { get; set; }

    public bool IsRacing { get; set; }

    public string Status => this.IsRacing ? this.TotalTime.ToString("f3") : this.FailureReason;

    public double TotalTime { get; set; }

    public Car Car { get; private set; }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public double FuelConsumptionPerKm { get; private set; }

    public void IncreaseTotalTime(int trackLength)
    {
        this.TotalTime += 60 / (trackLength / this.Speed);
    }

    public void GoToBox(List<string> args)
    {
        string commandType = args[0];

        this.TotalTime += needeTimeToGoToBox;

        if (commandType == "Refuel")
        {
            double fuelAmount = double.Parse(args[2]);
            this.Car.Refuel(fuelAmount);
        }
        else if (commandType == "ChangeTyres")
        {
            string tyreType = args[2];
            double hardness = double.Parse(args[3]);
            double grip = 0;

            if (args.Count > 4)
            {
                grip = double.Parse(args[4]);
            }

            this.Car.ChangeTyre(tyreType, hardness, grip);
        }
    }
}
