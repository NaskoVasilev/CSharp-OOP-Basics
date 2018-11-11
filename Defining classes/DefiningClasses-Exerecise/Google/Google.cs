using System;
using System.Collections.Generic;

namespace Google
{
    class Google
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> data = new Dictionary<string, Person>();
            string command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = tokens[0];
                string commandType = tokens[1];

                if (!data.ContainsKey(personName))
                {
                    data.Add(personName, new Person(personName));
                }

                switch (commandType)
                {
                    case "company":
                        data[personName].Comapny = new Company(tokens[2], tokens[3], decimal.Parse(tokens[4]));
                        break;
                    case "pokemon":
                        data[personName].Pokemons.Add(new Pokemon(tokens[2], tokens[3]));
                        break;
                    case "parents":
                        data[personName].Parents.Add(new Parent(tokens[2], tokens[3]));
                        break;
                    case "children":
                        data[personName].Childern.Add(new Child(tokens[2], tokens[3]));
                        break;
                    case "car":
                        data[personName].Car = new Car(tokens[2], tokens[3]);
                        break;
                }
            }

            string targetName = Console.ReadLine();

            if (data.ContainsKey(targetName))
            {
                Person targetPerson = data[targetName];
                Console.WriteLine(targetPerson.Name);
                Console.WriteLine("Company:");
                if (targetPerson.Comapny != null)
                {
                    Console.WriteLine(targetPerson.Comapny.ToString());
                }
                Console.WriteLine("Car:");
                if (targetPerson.Car != null)
                {
                    Console.WriteLine(targetPerson.Car.ToString());
                }
                Console.WriteLine("Pokemon:");
                targetPerson.Pokemons.ForEach(p => Console.WriteLine(p.ToString()));
                Console.WriteLine("Parents:");
                targetPerson.Parents.ForEach(p => Console.WriteLine(p.ToString()));
                Console.WriteLine("Children:");
                targetPerson.Childern.ForEach(c => Console.WriteLine(c.ToString()));
            }
        }
    }
}
