using Society.Contracts;
using Society.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Society.Core
{
    public class BorderControl
    {
        private ICollection<IIdentifiable> residents;

        public BorderControl()
        {
            this.residents = new List<IIdentifiable>();
        }

        public void Run()
        {
            string command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command.Split();

                if (data.Length == 3)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];

                    IIdentifiable person = new Citizen(name, age, id);
                    residents.Add(person);
                }
                else
                {
                    string model = data[0];
                    string id = data[1];
                    IIdentifiable robot = new Robot(model, id);
                    residents.Add(robot);
                }
            }

            string fakeId = Console.ReadLine();

            foreach (var illegalresident in residents.Where(r => r.Id.EndsWith(fakeId)))
            {
                Console.WriteLine(illegalresident.Id);
            }

            this.residents = this.residents.Where(x => !x.Id.EndsWith(fakeId)).ToList();
        }
    }
}
