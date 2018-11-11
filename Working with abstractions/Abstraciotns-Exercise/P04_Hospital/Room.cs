using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    class Room
    {
        public List<string> Patients { get; set; }

        public Room()
        {
            Patients = new List<string>();
        }
    }
}
