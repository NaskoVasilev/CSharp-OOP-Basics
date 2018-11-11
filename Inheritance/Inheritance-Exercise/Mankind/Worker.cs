using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WorkHoursPerDay = workHoursPerDay;
            this.WeekSalary = weekSalary;
        }

        public decimal WeekSalary
        {
            get { return weekSalary; }
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                weekSalary = value;
            }
        }


        public double WorkHoursPerDay
        {
            get { return workHoursPerDay; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            return WeekSalary / (decimal)(workHoursPerDay * 5);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($"Week Salary: {this.WeekSalary:F2}\n");
            sb.Append($"Hours per day: {this.workHoursPerDay:F2}\n");
            sb.Append($"Salary per hour: {this.MoneyPerHour():F2}");

            return sb.ToString();
        }
    }
}
