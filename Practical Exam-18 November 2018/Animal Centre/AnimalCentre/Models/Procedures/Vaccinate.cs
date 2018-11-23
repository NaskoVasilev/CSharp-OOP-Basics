namespace AnimalCentre.Models.Procedures
{
    using Contracts;

    public class Vaccinate : Procedure
    {
        public Vaccinate() : base()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckProcedureTime(animal.ProcedureTime, procedureTime);

            animal.Energy -= 8;
            animal.IsVaccinated = true;
            base.SubtractProcedureTimeAndAddAnimal(animal, procedureTime);
        }
    }
}
