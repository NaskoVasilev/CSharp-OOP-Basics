using MilitaryElite.Contracts;
using System;

namespace MilitaryElite.Models
{
    public class Private : Soldier , IPrivate
    {
        public decimal Salary { get; private set; }

        public Private(string id, string firstName, string lastName,decimal salary) 
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public override string ToString()
        {
            return base.ToString() + $"Salary: {Salary:F2}";
        }
    }
}
