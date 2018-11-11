using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] data = Console.ReadLine().Split();
                string model = data[0];
                int speed = int.Parse(data[1]);
                int power = int.Parse(data[2]);
                int weight = int.Parse(data[3]);
                string cargoType = data[4];
                int index = 0;
                Tire[] tires = new Tire[4];

                for (int j = 0; j < 8; j += 2)
                {
                    double pressure = double.Parse(data[5 + j]);
                    int age = int.Parse(data[6 + j]);
                    tires[index] = new Tire(pressure, age);
                    index++;
                }

                Engine engine = new Engine(speed, power);
                Cargo cargo = new Cargo(weight, cargoType);

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string type = Console.ReadLine();
            List<Car> targetCars = new List<Car>();

            if (type == "fragile")
            {
                targetCars = cars.Where(c => c.Cargo.CargoType == type && c.Tires.Any(x => x.Pressure < 1)).ToList();
            }
            else
            {
                targetCars = cars.Where(c => c.Cargo.CargoType == type && c.Engine.Power > 250).ToList();
            }

            foreach (var car in targetCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
