using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    class Car
    {
        public string  Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Color = "n/a";
            this.Weight = "n/a";
        }

        public override string ToString()
        {
            return $"{this.Model}:\n  {this.Engine.ToString()}\n  Weight: {this.Weight}\n  Color: {this.Color}";
        }
    }
}
