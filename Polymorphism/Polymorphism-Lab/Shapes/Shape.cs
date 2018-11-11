using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public abstract class Shape
    {
        public abstract double CalculatePerimeter();

        public abstract double ClaculateArea();

        public virtual string Draw()
        {
            return "Drawing ";
        }
    }
}
