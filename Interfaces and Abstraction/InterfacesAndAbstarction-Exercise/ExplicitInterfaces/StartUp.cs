using ExplicitInterfaces.Contracts;
using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = "";
            List<Citizen> residents = new List<Citizen>();

            while ((command = Console.ReadLine())!="End")
            {
                string[] data = command.Split();
                string name = data[0];
                string country = data[1];
                int age = int.Parse(data[2]);

                residents.Add(new Citizen(name, age, country));
            }

            foreach (var citizen in residents)
            {
                IPerson person = citizen;
                Console.WriteLine(person.GetName());

                IResident resident = citizen;
                Console.WriteLine(resident.GetName());

            }
        }
    }
}
