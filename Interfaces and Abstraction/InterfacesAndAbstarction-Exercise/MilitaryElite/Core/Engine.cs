using MilitaryElite.Contracts;
using MilitaryElite.Models;
using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite.Core
{
    public class Engine
    {
        List<ISoldier> soldiers;

        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public void Run()
        {
            string command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command.Split();
                string type = data[0].ToLower();
                string id = data[1];
                string firstName = data[2];
                string lastName = data[3];

                switch (type)
                {
                    case "private":
                        decimal salary = decimal.Parse(data[4]);
                        ISoldier privateSoldier = new Private(id, firstName, lastName, salary);
                        this.soldiers.Add(privateSoldier);
                        break;
                    case "lieutenantgeneral":
                        AddLieutenantGeneral(id, firstName, lastName, data);
                        break;
                    case "engineer":
                        AddEngineer(id, firstName, lastName, data);
                        break;
                    case "commando":
                        AddCommando(id, firstName, lastName, data);
                        break;
                    case "spy":
                        int codeNumber = int.Parse(data[4]);
                        ISpy spy = new Spy(id, firstName, lastName, codeNumber);
                        this.soldiers.Add(spy);
                        break;

                }
            }

            PrintSoldiers();
        }

        private void AddCommando(string id, string firstName, string lastName, string[] data)
        {
            decimal salary = decimal.Parse(data[4]);
            bool isValidCorps = Enum.TryParse(data[5], out Corps corps);

            if (!isValidCorps)
            {
                return;
            }

            ICommando commando = new Commando(id, firstName, lastName, salary, corps);

            for (int i = 6; i < data.Length; i += 2)
            {
                string missionCode = data[i];
                bool isValidMissionState = Enum.TryParse(data[i + 1], out States missionState);

                if (isValidMissionState)
                {
                    commando.Missions.Add(new Mission(missionCode, missionState));
                }
            }

            this.soldiers.Add(commando);
        }

        private void AddEngineer(string id, string firstName, string lastName, string[] data)
        {
            decimal salary = decimal.Parse(data[4]);
            string corpsAsString = data[5];
            bool isValidCorps = Enum.TryParse(corpsAsString, out Corps corps);
            if (!isValidCorps)
            {
                return;
            }

            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

            for (int i = 6; i < data.Length; i += 2)
            {
                string partName = data[i];
                int hoursWorked = int.Parse(data[i + 1]);
                engineer.Repairs.Add(new Repair(partName, hoursWorked));
            }

            this.soldiers.Add(engineer);
        }

        private void AddLieutenantGeneral(string id, string firstName, string lastName, string[] data)
        {
            decimal salary = decimal.Parse(data[4]);
            ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

            for (int i = 5; i < data.Length; i++)
            {
                IPrivate targetPrivate = (IPrivate)this.GetSoldierById(data[i]);

                if (targetPrivate != null)
                {
                    lieutenantGeneral.Privates.Add(targetPrivate);
                }
            }

            this.soldiers.Add(lieutenantGeneral);
        }

        private ISoldier GetSoldierById(string id)
        {
            return this.soldiers.FirstOrDefault(x => x.Id == id);
        }

        private void PrintSoldiers()
        {
            foreach (var soldier in this.soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}
