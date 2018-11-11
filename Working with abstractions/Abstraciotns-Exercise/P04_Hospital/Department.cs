using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    class Department
    {
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }

        public Department(string name)
        {
            Name = name;
            Rooms = new List<Room>();
        }
    }
}
