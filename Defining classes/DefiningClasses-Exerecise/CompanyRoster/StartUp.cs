using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                decimal salary = decimal.Parse(data[1]);
                string position = data[2];
                string department = data[3];
                Employee employee = new Employee(name, salary, position, department);

                if (data.Length == 5)
                {
                    if (int.TryParse(data[4], out int result))
                    {
                        employee.Age = result;
                    }
                    else
                    {
                        employee.Email = data[4];
                    }
                }
                else if(data.Length == 6)
                {
                    employee.Email = data[4];
                    employee.Age = int.Parse(data[5]);
                }

                employees.Add(employee);
            }

            var highestSalaryDepartment = employees.GroupBy(x => x.Department).
                ToDictionary(x => x.Key, y => y.ToList())
                .OrderByDescending(x => x.Value.Sum(e => e.Salary))
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {highestSalaryDepartment.Key}");

            foreach (var employee in highestSalaryDepartment.Value.OrderByDescending(x=>x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
            }

        }
    }
}
