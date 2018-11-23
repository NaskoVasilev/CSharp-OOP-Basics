namespace AnimalCentre.Models.Animals
{
    using Contracts;
    using System;

    public abstract class Animal : IAnimal
    {
        private const int maxHappiness = 100;
        private const int maxEnergy = 100;

        private int happiness;
        private int energy;

        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            Name = name;
            Energy = energy;
            Happiness = happiness;
            ProcedureTime = procedureTime;
            Owner = "Centre";
        }

        public string Name { get; private set; }

        public int Happiness
        {
            get { return happiness; }
            set
            {
                if (value < 0 || value > maxHappiness)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                happiness = value;
            }
        }

        public int Energy
        {
            get { return energy; }
            set
            {
                if (value < 0 || value > maxEnergy)
                {
                    throw new ArgumentException("Invalid energy");
                }
                energy = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; }

        public bool IsAdopt { get; set; }

        public bool IsChipped { get; set; }

        public bool IsVaccinated { get; set; }
    }
}
