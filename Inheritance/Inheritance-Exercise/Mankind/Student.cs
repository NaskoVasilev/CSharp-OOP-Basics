using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return facultyNumber; }
            set
            {
                if (!Regex.IsMatch(value, @"^[A-Za-z0-9]{5,10}$"))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                facultyNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($"Faculty number: {this.FacultyNumber}");

            return sb.ToString();
        }
    }
}
