namespace AnimalCentre.Models.Procedures
{
    using Contracts;

    public class Play : Procedure
    {
        public Play() : base()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckProcedureTime(animal.ProcedureTime, procedureTime);

            animal.Happiness += 12;
            animal.Energy -= 6;
            base.SubtractProcedureTimeAndAddAnimal(animal, procedureTime);
        }
    }
}
