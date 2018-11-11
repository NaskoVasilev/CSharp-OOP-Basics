using System;
using System.Collections.Generic;

namespace CarSalesman
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            List<Car> cars = new List<Car>();
            int enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = data[0];
                int power = int.Parse(data[1]);
                Engine engine = new Engine(model, power);
                if (data.Length == 3)
                {
                    if (int.TryParse(data[2], out int result))
                    {
                        engine.Displacement = data[2];
                    }
                    else
                    {
                        engine.Efficiency = data[2];
                    }
                }
                else if (data.Length == 4)
                {
                    engine.Displacement = data[2];
                    engine.Efficiency = data[3];
                }

                engines.Add(model, engine);
            }

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = data[0];
                string engineModel = data[1];
                Car car = new Car(carModel, engines[engineModel]);
                if (data.Length == 3)
                {
                    if (int.TryParse(data[2], out int result))
                    {
                        car.Weight = data[2];
                    }
                    else
                    {
                        car.Color = data[2];
                    }
                }
                else if (data.Length == 4)
                {
                    car.Weight = data[2];
                    car.Color = data[3];
                }

                cars.Add(car);
            }

            cars.ForEach(c => Console.WriteLine(c.ToString()));
        }
    }
}
