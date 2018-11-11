using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class SpeedRacing
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] data = Console.ReadLine().Split();
                string model = data[0];
                double fuelAmount = double.Parse(data[1]);
                double fuelConsumption = double.Parse(data[2]);

                cars.Add(model, new Car(model, fuelAmount, fuelConsumption));
            }

            string command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();
                string model = tokens[1];
                int distance = int.Parse(tokens[2]);
                cars[model].DriveCar(distance);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Value.Model} {car.Value.FuelAmount:F2} {car.Value.TraveledDistance}");
            }
        }
    }
}
