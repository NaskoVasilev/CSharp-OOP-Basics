using System.Collections.Generic;

namespace P01_RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private List<Tire> tires;

        public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            this.Tires = tires;
        }

        public string Model
        {
            get => model;
            set => model = value;
        }

        public Engine Engine
        {
            get => engine;
            set => engine = value;
        }

        public Cargo Cargo
        {
            get => cargo;
            set => cargo = value;
        }
        public List<Tire> Tires
        {
            get => tires;
            set => tires = value;
        }
    }
}
