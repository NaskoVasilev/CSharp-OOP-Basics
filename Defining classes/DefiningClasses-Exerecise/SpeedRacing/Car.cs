using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumption { get; set; }
        public int TraveledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
            this.TraveledDistance = 0;
        }

        public void DriveCar(int distance)
        {
            double neededFuel = distance * this.FuelConsumption;

            if (neededFuel <= this.FuelAmount)
            {
                this.FuelAmount -= neededFuel;
                this.TraveledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
