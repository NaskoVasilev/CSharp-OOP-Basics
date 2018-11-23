using System;

public abstract class Harvester : Identificator
{
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        OreOutput = oreOutput;
        EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get => this.oreOutput;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("OreOutput");
            }
            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get => this.energyRequirement;
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException("EnergyRequirement");
            }
            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        string name = this.GetType().Name;
        string output = $"{name.Remove(name.IndexOf("Harvester"))} Harvester - {this.Id}\n";
        output += $"Ore Output: { OreOutput }\n";
        output += $"Energy Requirement: { EnergyRequirement }";

        return output;
    }
}

