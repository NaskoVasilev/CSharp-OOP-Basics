using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private DungeonMaster dungeonMaster;

        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            StringBuilder result = new StringBuilder();

            while (true)
            {
                try
                {
                    if (dungeonMaster.IsGameOver())
                    {
                        break;
                    }

                    string command = Console.ReadLine();

                    if (string.IsNullOrEmpty(command))
                    {
                        break;
                    }

                    string[] args = command.Split(' ');
                    string output = ParseCommand(args);
                    result.AppendLine(output);
                }
                catch (ArgumentException ex)
                {
                    result.AppendLine("Parameter Error: " + ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    result.AppendLine("Invalid Operation: " + ex.Message);
                }
            }

            result.AppendLine("Final stats:");
            result.AppendLine(dungeonMaster.GetStats());

            Console.WriteLine(result.ToString().TrimEnd());
        }

        private string ParseCommand(string[] args)
        {
            string commandType = args[0];
            string output = "";
            string[] data = args.Skip(1).ToArray();

            switch (commandType)
            {
                case "JoinParty":
                    output = dungeonMaster.JoinParty(data);
                    break;
                case "AddItemToPool":
                    output = dungeonMaster.AddItemToPool(data);
                    break;
                case "PickUpItem":
                    output = dungeonMaster.PickUpItem(data);
                    break;
                case "UseItemOn":
                    output = dungeonMaster.UseItemOn(data);
                    break;
                case "UseItem":
                    output = dungeonMaster.UseItem(data);
                    break;
                case "GiveCharacterItem":
                    output = dungeonMaster.GiveCharacterItem(data);
                    break;
                case "GetStats":
                    output = dungeonMaster.GetStats();
                    break;
                case "Attack":
                    output = dungeonMaster.Attack(data);
                    break;
                case "Heal":
                    output = dungeonMaster.Heal(data);
                    break;
                case "EndTurn":
                    output = dungeonMaster.EndTurn(data);
                    break;
                case "IsGameOver":
                    dungeonMaster.IsGameOver();
                    break;
                default:
                    throw new InvalidOperationException("Invalid command");
            }

            return output;
        }
    }
}
