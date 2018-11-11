using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    class Car
    {
        //format “<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType> <Tire1Pressure> 
        //<Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> <Tire4Pressure> <Tire4Age>
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }
    }
}
