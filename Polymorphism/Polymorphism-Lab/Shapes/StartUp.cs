using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(5, 4);

            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.ClaculateArea());
            Console.WriteLine(rectangle.Draw());

            Shape circle = new Circle(5);

            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.ClaculateArea());
            Console.WriteLine(circle.Draw());
        }
    }

}
