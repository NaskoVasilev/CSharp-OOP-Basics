namespace AnimalCentre.Models.Procedures
{
    using Contracts;

    public class Fitness : Procedure
    {
        public Fitness() : base()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckProcedureTime(animal.ProcedureTime, procedureTime);

            animal.Happiness -= 3;
            animal.Energy += 10;
            base.SubtractProcedureTimeAndAddAnimal(animal, procedureTime);
        }
    }
}
