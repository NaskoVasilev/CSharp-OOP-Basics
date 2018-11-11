using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyTree
{
    class FamilyTree
    {
        static List<Person> members;
        static void Main(string[] args)
        {
            List<string> relations = new List<string>();
            string targetData = Console.ReadLine();
            members = new List<Person>();

            string command = "";

            while ((command=Console.ReadLine())!="End")
            {
                if (!command.Contains("-"))
                {
                    string[] data = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string name = data[0] + " " + data[1];
                    members.Add(new Person(name, data[2]));
                }
                else
                {
                    relations.Add(command);
                }
            }

            foreach (var relation in relations)
            {
                string[] data = relation.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string parentData = data[0];
                string childData = data[1];

                var parent = FindPerson(parentData);
                var children = FindPerson(childData);
                parent.Childern.Add(children);
                children.Parents.Add(parent);
            }

            var targetPerson = FindPerson(targetData);
            Console.WriteLine($"{targetPerson.Name} {targetPerson.Birthday}");
            Console.WriteLine("Parents:");
            foreach (var parent in targetPerson.Parents)
            {
                Console.WriteLine($"{parent.Name} {parent.Birthday}");
            }
            Console.WriteLine("Children:");
            foreach (var child in targetPerson.Childern)
            {
                Console.WriteLine($"{child.Name} {child.Birthday}");
            }
        }

        private static Person FindPerson(string data)
        {
            if (data.Contains("/"))
            {
                return members.FirstOrDefault(x => x.Birthday == data);
            }
            else
            {
                return members.FirstOrDefault(x => x.Name == data);
            }
        }
    }
}
