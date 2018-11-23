namespace AnimalCentre.Models.Procedures
{
    using Contracts;
    using System;
    using System.Text;
    using System.Collections.Generic;

    public abstract class Procedure : IProcedure
    {
        private ICollection<IAnimal> procedureHistory;

        protected Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }

        protected ICollection<IAnimal> ProcedureHistory 
        {
            get => this.procedureHistory;
            private set => this.procedureHistory = value;
        }

        public abstract void DoService(IAnimal animal, int procedureTime);

        public string History()
        {
            StringBuilder history = new StringBuilder();

            history.AppendLine(this.GetType().Name);

            foreach (var animal in this.procedureHistory)
            {
                history.AppendLine(animal.ToString());
            }

            return history.ToString().TrimEnd();
        }

        protected void CheckProcedureTime(int animalProcedureTime, int procedureTime)
        {
            if (animalProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
        }

        protected void SubtractProcedureTimeAndAddAnimal(IAnimal animal, int procedureTime)
        {
            animal.ProcedureTime -= procedureTime;
            this.procedureHistory.Add(animal);
        }
    }
}
