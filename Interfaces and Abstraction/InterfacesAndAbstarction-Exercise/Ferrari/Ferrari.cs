using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : ICar
    {
        private const string model = "488-Spider";

        public string Driver { get; set; }

        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Brake()
        {
            return "Brakes!";
        }

        public string PushGasPedal()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{model}/{this.Brake()}/{this.PushGasPedal()}/{this.Driver}";
        }
    }
}
