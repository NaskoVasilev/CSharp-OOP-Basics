using Society.Contracts;
using Society.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Society.Core
{
    public class BirthdayCelebration
    {
        private List<IBirthable> birthdays;

        public BirthdayCelebration()
        {
            this.birthdays = new List<IBirthable>();
        }

        public void Run()
        {
            string command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command.Split();
                string type = data[0];
                string name = data[1];

                if (type == "Pet")
                {
                    string birthdate = data[2];
                    this.birthdays.Add(new Pet(name, birthdate));
                }
                else if (type == "Citizen")
                {
                    int age = int.Parse(data[2]);
                    string id = data[3];
                    string birthdate = data[4];
                    this.birthdays.Add(new Citizen(name, age, id, birthdate));
                }
            }

            string targetYear = Console.ReadLine();

            foreach (var birthdate in birthdays.Where(x => x.Birthdate.EndsWith(targetYear)))
            {
                Console.WriteLine(birthdate.Birthdate);
            }
        }
    }
}
