using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                height = value;
            }
        }

        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                width = value;
            }
        }

        public override double ClaculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.Width + this.Height);

        }

        public override string Draw()
        {
            return base.Draw() + "Rectangle";
        }
    }
}
