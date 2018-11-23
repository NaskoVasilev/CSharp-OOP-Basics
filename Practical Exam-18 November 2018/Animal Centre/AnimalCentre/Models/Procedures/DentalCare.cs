namespace AnimalCentre.Models.Procedures
{
    using Contracts;

    public class DentalCare : Procedure
    {
        public DentalCare() : base()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckProcedureTime(animal.ProcedureTime, procedureTime);

            animal.Happiness += 12;
            animal.Energy += 10;
            base.SubtractProcedureTimeAndAddAnimal(animal, procedureTime);
        }
    }
}
