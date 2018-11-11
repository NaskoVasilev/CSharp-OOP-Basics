using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] peopleInput = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            string[] productsInput = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            List<Product> products = new List<Product>();
            List<Person> people = new List<Person>();

            try
            {
                for (int i = 0; i < peopleInput.Length; i++)
                {
                    string[] data = peopleInput[i].Split('=');
                    string name = data[0];
                    decimal money = decimal.Parse(data[1]);
                    people.Add(new Person(name, money));
                }

                for (int i = 0; i < productsInput.Length; i++)
                {
                    string[] data = productsInput[i].Split('=');
                    string name = data[0];
                    decimal cost = decimal.Parse(data[1]);
                    products.Add(new Product(name, cost));
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return;
            }

            string command = "";

            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = data[0];
                string productName = data[1];

                Product product = products.First(p => p.Name == productName);
                people.First(p => p.Name == personName).AddProduct(product);
            }

            people.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
