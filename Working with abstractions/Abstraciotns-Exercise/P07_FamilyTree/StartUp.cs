using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_FamilyTree
{
    class StartUp
    {
        static List<Person> familyTree;

        static void Main(string[] args)
        {
            List<string> relationships = new List<string>();
            familyTree = new List<Person>();
            string targetPersonData = Console.ReadLine();
            string command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" - ");
                if (tokens.Length > 1)
                {
                    relationships.Add(command);
                }
                else
                {
                    string[] data = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string name = data[0] + " " + data[1];
                    familyTree.Add(new Person(name, data[2]));
                }
            }

            SetRelationships(relationships);

            PrintTargetPersonData(targetPersonData);
        }

        private static void SetRelationships(List<string> relationships)
        {
            foreach (var relationship in relationships)
            {
                string[] data = relationship.Split(" - ");

                Person parent = GetPerson(data[0]);
                Person child = GetPerson(data[1]);
                parent.Children.Add(child);
                child.Parents.Add(parent);
            }
        }

        private static void PrintTargetPersonData(string targetPersonData)
        {
            Person targetPerson = GetPerson(targetPersonData);

            Console.WriteLine(targetPerson.ToString());
            Console.WriteLine("Parents:");

            foreach (var parent in targetPerson.Parents)
            {
                Console.WriteLine(parent.ToString());
            }

            Console.WriteLine("Children:");
            foreach (var child in targetPerson.Children)
            {
                Console.WriteLine(child.ToString());
            }
        }

        private static Person GetPerson(string personData)
        {
            Person targetPerson;
            if (IsBirthday(personData))
            {
                targetPerson = familyTree.FirstOrDefault(x => x.Birthday == personData);
            }
            else
            {
                targetPerson = familyTree.FirstOrDefault(x => x.Name == personData);
            }
            return targetPerson;
        }

        static bool IsBirthday(string input)
        {
            return Char.IsDigit(input[0]);
        }
    }
}
