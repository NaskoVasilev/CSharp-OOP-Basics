using System;
using System.Linq;

namespace PointInRectangle
{
    class PointInRectangle
    {
        static void Main(string[] args)
        {
            int[] coordinates = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Point topLeft = new Point(coordinates[0], coordinates[1]);
            Point bottomRight = new Point(coordinates[2], coordinates[3]);
            Rectangle rectangle = new Rectangle(topLeft, bottomRight);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                Point currentPoint = new Point(int.Parse(data[0]), int.Parse(data[1]));
                Console.WriteLine(rectangle.Contains(currentPoint));
            }
        }
    }
}
