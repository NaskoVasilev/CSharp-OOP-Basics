using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Problem 3. Oldest Family Member

            //int n = int.Parse(Console.ReadLine());
            //Family family = new Family();

            //for (int i = 0; i < n; i++)
            //{
            //    string[] data = Console.ReadLine().Split();
            //    string name = data[0];
            //    int age = int.Parse(data[1]);

            //    family.AddMember(new Person(name, age));
            //}

            //Person oldestPerson = family.GetOldestMember();
            //Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");


            //Problem 4. Opinion Poll
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                int age = int.Parse(data[1]);

                if (age > 30)
                {
                    people.Add(new Person(name, age));
                }
            }

            foreach (var person in people.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
