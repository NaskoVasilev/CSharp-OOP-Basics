using System;
using System.Collections.Generic;

namespace StudentSystem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Student> repository = new Dictionary<string, Student>();
            string input = "";

            while ((input = Console.ReadLine()) != "Exit")
            {
                string[] data = input.Split();
                string command = data[0];

                switch (command)
                {
                    case "Create":
                        CreateStudent(repository, data);
                        break;
                    case "Show":
                        PrintStudent(repository, data);
                        break;
                }
            }
        }

        private static void PrintStudent(Dictionary<string, Student> repository, string[] data)
        {
            string studentName = data[1];
            if (repository.ContainsKey(studentName))
            {
                Console.WriteLine(repository[studentName].ToString());
            }
        }

        private static void CreateStudent(Dictionary<string, Student> repository, string[] data)
        {
            var name = data[1];
            var age = int.Parse(data[2]);
            var grade = double.Parse(data[3]);
            if (!repository.ContainsKey(name))
            {
                Student student = new Student(name, age, grade);
                repository.Add(name, student);
            }
        }
    }
}


