using Society.Contracts;
using Society.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Society.Core
{
    public class FoodStorage
    {
        private List<IBuyer> buyers;

        public FoodStorage()
        {
            this.buyers = new List<IBuyer>();
        }

        public void Run()
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                if (tokens.Length == 4)
                {
                    string id = tokens[2];
                    string birthdate = tokens[3];
                    buyers.Add(new Citizen(name, age, id, birthdate));
                }
                else
                {
                    string group = tokens[2];
                    buyers.Add(new Rebel(name, age, group));
                }
            }

            string targetName = "";

            while ((targetName = Console.ReadLine()) != "End")
            {
                IBuyer targetBuyer = buyers.FirstOrDefault(x => x.Name == targetName);

                if (targetBuyer != null)
                {
                    targetBuyer.BuyFood();
                }
            }

            int totalFood = buyers.Sum(x => x.Food);
            Console.WriteLine(totalFood);
        }
    }
}
