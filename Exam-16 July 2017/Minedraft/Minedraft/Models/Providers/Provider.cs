using System;

public abstract class Provider : Identificator
{
    private double energyOutput;

    protected Provider(string id, double energyOutput) : base(id)
    {
        EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get => this.energyOutput;
        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException("EnergyOutput");
            }
            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        string name = this.GetType().Name;
        return $"{name.Remove(name.IndexOf("Provider"))} Provider - {this.Id}\nEnergy Output: { this.EnergyOutput }";
    }
}

