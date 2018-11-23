namespace AnimalCentre
{
    using Core;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            AnimalCentre animalCentre = new AnimalCentre();
            Engine engine = new Engine(animalCentre);
            engine.Run();
        }
    }
}
