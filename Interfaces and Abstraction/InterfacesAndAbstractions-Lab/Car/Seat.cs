using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public string Model { get; }

        public string Color { get; set; }

        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            string output = $"{this.Color} Seat {this.Model}\n";
            output += this.Start() + "\n";
            output += this.Stop();

            return output;
        }
    }
}
