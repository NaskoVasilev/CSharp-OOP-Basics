using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    class Engine
    {
        public string EngineModel { get; set; }
        public int Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }

        public Engine(string engineModel, int power)
        {
            this.EngineModel = engineModel;
            this.Power = power;
            this.Displacement = "n/a";
            this.Efficiency = "n/a";
        }

        public override  string ToString()
        {
            return $"{this.EngineModel}:\n    Power: {this.Power}\n    Displacement: {this.Displacement}\n    Efficiency: {this.Efficiency}";
        }
    }
}
