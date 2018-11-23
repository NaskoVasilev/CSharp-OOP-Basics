namespace AnimalCentre.Core
{
    using Models.Factories;
    using Models.Procedures;
    using Models.Contracts;
    using Models.Hotels;
    using System;
    using System.Collections.Generic;

    public class AnimalCentre
    {
        private IHotel hotel;
        private AnimalFactory animalFactory;
        Dictionary<string, IProcedure> procedures;
        private Dictionary<string, List<string>> owners;

        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.animalFactory = new AnimalFactory();
            this.owners = new Dictionary<string, List<string>>();
            this.procedures = new Dictionary<string, IProcedure>();
            this.InitializeAllProcedures();
        }

        public IReadOnlyDictionary<string, List<string>> Owners => this.owners;

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal = animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);
            this.hotel.Accommodate(animal);

            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            IAnimal animal = GetAnimal(name);
            this.procedures["Chip"].DoService(animal, procedureTime);

            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            IAnimal animal = GetAnimal(name);
            this.procedures["Vaccinate"].DoService(animal, procedureTime);

            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            IAnimal animal = GetAnimal(name);
            this.procedures["Fitness"].DoService(animal, procedureTime);

            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            IAnimal animal = GetAnimal(name);
            this.procedures["Play"].DoService(animal, procedureTime);

            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            IAnimal animal = GetAnimal(name);
            this.procedures["DentalCare"].DoService(animal, procedureTime);

            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            IAnimal animal = GetAnimal(name);
            this.procedures["NailTrim"].DoService(animal, procedureTime);

            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            IAnimal animal = GetAnimal(animalName);
            AddOwner(animalName, owner);

            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }
            return $"{owner} adopted animal without chip";
        }

        public string History(string type)
        {
            IProcedure procedure = this.procedures[type];
            return procedure.History();
        }

        private IAnimal GetAnimal(string animalName)
        {
            if (!hotel.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            return this.hotel.Animals[animalName];
        }

        private void InitializeAllProcedures()
        {
            procedures.Add("Chip", new Chip());
            procedures.Add("Vaccinate", new Vaccinate());
            procedures.Add("Play", new Play());
            procedures.Add("NailTrim", new NailTrim());
            procedures.Add("Fitness", new Fitness());
            procedures.Add("DentalCare", new DentalCare());
        }

        private void AddOwner(string animalName, string ownerName)
        {
            if (!this.owners.ContainsKey(ownerName))
            {
                this.owners.Add(ownerName, new List<string>());
            }
            this.owners[ownerName].Add(animalName);
        }
    }
}
