using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    IList<Harvester> harvesters;
    IList<Provider> providers;
    HarvesterFactory harvesterFactory;
    ProviderFactory providerFactory;
    Mode currentMode;
    double totalStoredEnergy;
    double totalMinedOre;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
        this.currentMode = global::Mode.Full;
        this.totalStoredEnergy = 0d;
        totalStoredEnergy = 0d;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        
        try
        {
            Harvester harvester = harvesterFactory.CreateHarvester(arguments);
            this.harvesters.Add(harvester);
        }
        catch (ArgumentException ex)
        {
            return $"Harvester is not registered, because of it's {ex.Message}";
        }

        return $"Successfully registered {type} Harvester - {id}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        try
        {
            Provider provider = providerFactory.CreateProvider(type, id, energyOutput);
            providers.Add(provider);
        }
        catch (ArgumentException ex)
        {
            return $"Provider is not registered, because of it's {ex.Message}";
        }

        return $"Successfully registered {type} Provider - {id}";
    }

    public string Day()
    {
        double energy = this.providers.Sum(x => x.EnergyOutput);
        this.totalStoredEnergy += energy;
        double energyRequirementsSum = this.harvesters.Sum(x => x.EnergyRequirement);
        double minedOre = this.harvesters.Sum(x => x.OreOutput);

        if (this.currentMode == global::Mode.Half)
        {
            energyRequirementsSum *= 0.6;
            minedOre *= 0.5;
        }

        if (totalStoredEnergy >= energyRequirementsSum && this.currentMode != global::Mode.Energy)
        {
            this.totalMinedOre += minedOre;
            this.totalStoredEnergy -= energyRequirementsSum;
        }
        else
        {
            minedOre = 0;
        }

        string output = "A day has passed.\n";
        output += $"Energy Provided: { energy }\n";
        output += $"Plumbus Ore Mined: { minedOre }";

        return output;
    }

    public string Mode(List<string> arguments)
    {
        string modeAsString = arguments[0];
        Enum.TryParse(modeAsString, out Mode mode);
        this.currentMode = mode;
        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        Identificator element = (Identificator)this.harvesters.FirstOrDefault(x => x.Id == id)
            ?? this.providers.FirstOrDefault(p => p.Id == id);
        
        if(element != null)
        {
            return element.ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: { this.totalStoredEnergy }");
        sb.AppendLine($"Total Mined Plumbus Ore: { this.totalMinedOre }");

        return sb.ToString().TrimEnd();
    }

}

