using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public int Battery { get; }

        public string Model { get; }

        public string Color { get; set; }

        public Tesla(string color, string model, int battery)
        {
            Battery = battery;
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
            string output = $"{Color} Tesla {Model} with {Battery} Batteries\n";
            output += this.Start() + "\n";
            output += this.Stop();

            return output;
        }
    }
}
