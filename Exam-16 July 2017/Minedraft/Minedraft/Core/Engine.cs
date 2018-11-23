using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private DraftManager draftManager;

    public Engine()
    {
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        string command;
        StringBuilder sb = new StringBuilder();

        while ((command = Console.ReadLine())!="Shutdown")
        {
            sb.AppendLine(ParseCommand(command));
        }

        sb.AppendLine(draftManager.ShutDown());

        Console.WriteLine(sb.ToString().TrimEnd());
    }

    private string ParseCommand(string input)
    {
        string[] data = input.Split();
        string command = data[0];
        List<string> arguments = data.Skip(1).ToList();

        switch(command)
        {
            case "RegisterHarvester":
                return draftManager.RegisterHarvester(arguments);
            case "RegisterProvider":
                return draftManager.RegisterProvider(arguments);
            case "Day":
                return draftManager.Day();
            case "Mode":
                return draftManager.Mode(arguments);
            case "Check":
                return draftManager.Check(arguments);
            default:
                throw new ArgumentException("Invalid command!");
        }
    }
}
