using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    class Doctor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Patients { get; set; }

        public Doctor(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Patients = new List<string>();
        }

        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }
    }
}
