using System;

namespace ClassBox
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(length, width, height);

                Console.WriteLine($"Surface Area - {box.GetSurafaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.GetLiteralSurfaceArea():F2}");
                Console.WriteLine($"Volume - {box.GetVolume():F2}");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
