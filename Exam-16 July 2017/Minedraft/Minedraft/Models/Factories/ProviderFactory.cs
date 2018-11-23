using System;

public class ProviderFactory
{
    public Provider CreateProvider(string type, string id, double energyOutput)
    {
        switch (type)
        {
            case "Solar":
                return new SolarProvider(id, energyOutput);
            case "Pressure":
                return new PressureProvider(id, energyOutput);
            default:
                throw new ArgumentException("Invalid Provider Type");
        }
    }
}
