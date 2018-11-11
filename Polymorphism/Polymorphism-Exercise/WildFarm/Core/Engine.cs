using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Contracts;
using WildFarm.Animals.Factories;
using WildFarm.Food.Contracts;
using WildFarm.Food.Factory;

namespace WildFarm.Core
{
    public class Engine
    {
        private FelineFactory felineFactory;
        private BirdFactory birdFactory;
        private MammalFactory mammalFactory;
        private FoodFactory foodFactory;
        private IAnimal animal;
        List<IAnimal> animals;

        public Engine()
        {
            felineFactory = new FelineFactory();
            birdFactory = new BirdFactory();
            mammalFactory = new MammalFactory();
            foodFactory = new FoodFactory();
            animals = new List<IAnimal>();
        }

        public void Run()
        {
            string command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalInfo = command.Split();
                string[] foodInfo = Console.ReadLine().Split();

                string animalType = animalInfo[0].ToLower();
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);

                if (animalType == "cat" || animalType == "tiger")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    animal = (IAnimal)felineFactory.CreateFeline(animalType, name, weight, livingRegion, breed);
                }
                else if (animalType == "owl" || animalType == "hen")
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    animal = (IAnimal)birdFactory.CreateBird(animalType, name, weight, wingSize);
                }
                else if (animalType == "mouse" || animalType == "dog")
                {
                    string livingRegion = animalInfo[3];
                    animal = (IAnimal)mammalFactory.CreateMammal(animalType, name, weight, livingRegion); 
                }

                animals.Add(animal);
                animal.ProduceSound();

                try
                {
                    string foodType = foodInfo[0];
                    double quantity =double.Parse(foodInfo[1]);

                    IFood food = foodFactory.CreateFood(foodType, quantity);
                    animal.Eat(food);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
