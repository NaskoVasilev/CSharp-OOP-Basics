using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Vehicles;

namespace Vehicles.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carInfo[1]); 
            double carFuelConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);
            IVehicle car = new Car(carFuelQuantity, carFuelConsumption,carTankCapacity);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);
            IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption,truckTankCapacity);

            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);
            IVehicle bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

            int vehiclesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < vehiclesCount; i++)
            {
                string[] data = Console.ReadLine().Split();
                string command = data[0];
                string vehicleType = data[1];
                double value = double.Parse(data[2]);

                try
                {
                    if (vehicleType == "Car")
                    {
                        if (command == "Drive")
                        {
                            car.Drive(value);
                        }
                        else if (command == "Refuel")
                        {
                            car.Refuel(value);
                        }
                    }
                    else if (vehicleType == "Truck")
                    {
                        if (command == "Drive")
                        {
                            truck.Drive(value);
                        }
                        else if (command == "Refuel")
                        {
                            truck.Refuel(value);
                        }
                    }
                    else if(vehicleType == "Bus")
                    {
                        if(command == "Drive")
                        {
                            bus.VehicleIsEmpty = false;
                            bus.Drive(value);
                        }
                        else if(command == "DriveEmpty")
                        {
                            bus.VehicleIsEmpty = true;
                            bus.Drive(value);
                        }
                        else if(command == "Refuel")
                        {
                            bus.Refuel(value);
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
