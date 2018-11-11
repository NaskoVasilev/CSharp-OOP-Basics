using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class StartUp
    {
        static List<Doctor> doctors;
        static List<Department> departments;

        public static void Main()
        {
            doctors = new List<Doctor>();
            departments = new List<Department>();
            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] data = command.Split();
                var departamentName = data[0];
                var firstName = data[1];
                var lastName = data[2];
                var patient = data[3];

                Doctor doctor = GetDoctor(firstName, lastName);
                Department department = GetDepartment(departamentName);

                bool thereIsFreeSpace = department.Rooms.Sum(x => x.Patients.Count) < 60;

                if (thereIsFreeSpace)
                {
                    int targetRoom = 0;
                    doctor.Patients.Add(patient);

                    for (int room = 0; room < department.Rooms.Count; room++)
                    {
                        if (department.Rooms[room].Patients.Count < 3)
                        {
                            targetRoom = room;
                            break;
                        }
                    }
                    department.Rooms[targetRoom].Patients.Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();
                List<string> patients = new List<string>();

                if (args.Length == 1)
                {
                    patients = GetDepartment(args[0]).Rooms
                        .Where(x => x.Patients.Count > 0)
                        .SelectMany(x => x.Patients).ToList();
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int targetRoom))
                {
                    patients = GetDepartment(args[0]).Rooms[targetRoom - 1].Patients
                        .OrderBy(x => x)
                        .ToList();
                }
                else
                {
                    patients = GetDoctor(args[0], args[1]).Patients.OrderBy(x => x).ToList();
                }
                Console.WriteLine(string.Join(Environment.NewLine,patients));

                command = Console.ReadLine();
            }
        }


        private static Department GetDepartment(string departamentName)
        {
            Department department = departments
                .FirstOrDefault(x => x.Name == departamentName);

            if (department == null)
            {
                department = new Department(departamentName);
                for (int i = 0; i < 20; i++)
                {
                    department.Rooms.Add(new Room());
                }
                departments.Add(department);
            }

            return department;
        }

        private static Doctor GetDoctor(string firstName, string lastName)
        {
            Doctor doctor = doctors
                .FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (doctor == null)
            {
                doctor = new Doctor(firstName, lastName);
                doctors.Add(doctor);
            }

            return doctor;
        }
    }
}
