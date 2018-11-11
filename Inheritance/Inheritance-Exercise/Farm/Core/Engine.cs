using Farm.Animals;
using Farm.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.Core
{
    public class Engine
    {
        private List<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string type = "";

            while ((type = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    string[] data = Console.ReadLine().Split(' ');
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string gender = data[2];

                    Animal currentAnimal = AnimalFactory.CreateAnimal(type, name, age, gender);
                    animals.Add(currentAnimal);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
                animal.ProduceSound();
            }
        }
    }
}
