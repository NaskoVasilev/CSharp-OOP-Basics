using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override double ClaculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public sealed override string Draw()
        {
            return base.Draw() + "Circle";
        }
    }
}
