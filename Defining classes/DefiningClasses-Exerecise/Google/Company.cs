using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    class Company
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }

        public Company(string name, string department, decimal salary)
        {
            this.Name = name;
            this.Department = department;
            this.Salary = salary;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Department} {this.Salary:F2}";
        }

    }
}
