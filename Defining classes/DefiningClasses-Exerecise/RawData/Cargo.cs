using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    class Cargo
    {
        public int Weight { get; set; }
        public string CargoType { get; set; }

        public Cargo(int weight, string cargoType)
        {
            this.Weight = weight;
            this.CargoType = cargoType;
        }
    }
}
