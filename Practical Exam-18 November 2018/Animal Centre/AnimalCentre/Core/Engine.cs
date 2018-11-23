namespace AnimalCentre.Core
{
    using System;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        private AnimalCentre animalCentre;
        private StringBuilder output;
        public Engine(AnimalCentre animalCentre)
        {
            this.animalCentre = animalCentre;
            this.output = new StringBuilder();
        }

        public void Run()
        {
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command.Split();

                try
                {
                    output.AppendLine(ParseCommand(data));
                }
                catch (InvalidOperationException ex)
                {
                    output.AppendLine($"InvalidOperationException: " + ex.Message);
                }
                catch (ArgumentException ex)
                {
                    output.AppendLine($"ArgumentException: " + ex.Message);
                }
            }

            Console.WriteLine(output.ToString().TrimEnd());
            this.PrintOwners();
        }

        private string ParseCommand(string[] data)
        {
            string commandType = data[0];
            int procedureTime = 0;
            string name = "";
            switch (commandType)
            {
                case "RegisterAnimal":
                    string type = data[1];
                    name = data[2];
                    int energy = int.Parse(data[3]);
                    int happiness = int.Parse(data[4]);
                    procedureTime = int.Parse(data[5]);
                    return animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime);
                case "Chip":
                    name = data[1];
                    procedureTime = int.Parse(data[2]);
                    return animalCentre.Chip(name, procedureTime);
                case "Vaccinate":
                    name = data[1];
                    procedureTime = int.Parse(data[2]);
                    return animalCentre.Vaccinate(name, procedureTime);
                case "Fitness":
                    name = data[1];
                    procedureTime = int.Parse(data[2]);
                    return animalCentre.Fitness(name, procedureTime);
                case "Play":
                    name = data[1];
                    procedureTime = int.Parse(data[2]);
                    return animalCentre.Play(name, procedureTime);
                case "DentalCare":
                    name = data[1];
                    procedureTime = int.Parse(data[2]);
                    return animalCentre.DentalCare(name, procedureTime);
                case "NailTrim":
                    name = data[1];
                    procedureTime = int.Parse(data[2]);
                    return animalCentre.NailTrim(name, procedureTime);
                case "Adopt":
                    name = data[1];
                    string owner = data[2];
                    return animalCentre.Adopt(name, owner);
                case "History":
                    string procedureType = data[1];
                    return animalCentre.History(procedureType);
                default:
                    throw new ArgumentException("Invalid command type!");
            }
        }

        private void PrintOwners()
        {
            foreach (var owner in animalCentre.Owners.OrderBy(x => x.Key))
            {
                Console.WriteLine($"--Owner: {owner.Key}");
                Console.WriteLine($"    - Adopted animals: {string.Join(" ", owner.Value)}");
            }
        }
    }
}
