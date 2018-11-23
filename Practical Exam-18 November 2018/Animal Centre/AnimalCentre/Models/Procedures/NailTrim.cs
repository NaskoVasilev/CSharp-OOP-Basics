namespace AnimalCentre.Models.Procedures
{
    using Contracts;

    public class NailTrim : Procedure
    {
        public NailTrim() : base()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckProcedureTime(animal.ProcedureTime,procedureTime);

            animal.Happiness -= 7;
            base.SubtractProcedureTimeAndAddAnimal(animal, procedureTime);
        }
    }
}
