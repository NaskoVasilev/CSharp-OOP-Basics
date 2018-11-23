using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class Engine
    {
        private StorageMaster storageMaster;

        public Engine()
        {
            this.storageMaster = new StorageMaster();
        }

        public void Run()
        {
            string command = "";
            string output = "";
            StringBuilder result = new StringBuilder();

            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] data = command.Split(" ");
                    output = CommandParser(data);
                    result.AppendLine(output);
                }
                catch (InvalidOperationException ex)
                {
                    result.AppendLine("Error: " + ex.Message);
                }
            }

            Console.WriteLine(result.ToString().Trim());
            string summary = storageMaster.GetSummary();
            Console.WriteLine(summary);
        }

        private string CommandParser(string[] data)
        {
            string command = data[0];
            string type = "";
            int garageSlot = 0;
            string storageName = "";
            string result = "";

            switch (command)
            {
                case "AddProduct":
                    type = data[1];
                    double price = double.Parse(data[2]);
                    result = storageMaster.AddProduct(type, price);
                    break;
                case "RegisterStorage":
                    type = data[1];
                    string name = data[2];
                    result = storageMaster.RegisterStorage(type, name);
                    break;
                case "SelectVehicle":
                    storageName = data[1];
                    garageSlot = int.Parse(data[2]);
                    result = storageMaster.SelectVehicle(storageName, garageSlot);
                    break;
                case "LoadVehicle":
                    IEnumerable<string> productNames = data.Skip(1);
                    result = storageMaster.LoadVehicle(productNames);
                    break;
                case "SendVehicleTo":
                    string sourceName = data[1];
                    int sourceGarageSlot = int.Parse(data[2]);
                    string destinationName = data[3];
                    result = storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);
                    break;
                case "UnloadVehicle":
                    storageName = data[1];
                    garageSlot = int.Parse(data[2]);
                    result = storageMaster.UnloadVehicle(storageName, garageSlot);
                    break;
                case "GetStorageStatus":
                    storageName = data[1];
                    result = storageMaster.GetStorageStatus(storageName);
                    break;
            }

            return result;
        }

    }
}
