using System;
using System.Collections.Generic;
using System.Text;

namespace RectangularIntersection
{
    class Rectangle
    {
        public string Id { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public Rectangle(string id, double width, double height, double x, double y)
        {
            this.Id = id;
            this.Width = width;
            this.Height = height;
            this.X = x;
            this.Y = y;
        }

        public bool IntersectWith(Rectangle rectangle)
        {
            bool intersect = this.X + this.Width < rectangle.X
                || rectangle.X + rectangle.Width < this.X
                || this.Y + this.Height < rectangle.Y
                || rectangle.Y + rectangle.Height < this.Y;
            if (intersect)
            {
                return false;
            }

            return true;
        }
    }
}
