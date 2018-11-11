using System;
using System.Collections.Generic;

namespace RectangularIntersection
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Rectangle> rectangles = new Dictionary<string, Rectangle>();
            string[] data = Console.ReadLine().Split();
            int recranglesCount = int.Parse(data[0]);
            int intersectionCount = int.Parse(data[1]);

            for (int i = 0; i < recranglesCount; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string id = tokens[0];
                double width = double.Parse(tokens[1]);
                double height = double.Parse(tokens[2]);
                double x = double.Parse(tokens[3]);
                double y = double.Parse(tokens[4]);
                if (rectangles.ContainsKey(id) == false)
                {
                    rectangles.Add(id, new Rectangle(id, width, height, x, y));
                }
            }

            for (int i = 0; i < intersectionCount; i++)
            {
                string[] ids = Console.ReadLine().Split();
                string firstId = ids[0];
                string secondId = ids[1];
                if (rectangles.ContainsKey(firstId) && rectangles.ContainsKey(secondId))
                {
                    bool intersect = rectangles[firstId].IntersectWith(rectangles[secondId]);
                    Console.WriteLine(intersect.ToString().ToLower());
                }
                else
                {
                    Console.WriteLine("false");
                }

            }
        }
    }
}
