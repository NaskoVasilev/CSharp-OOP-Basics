using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBox
{
    class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }       

        private double Length
        {
            set
            {
                if (value <= 0)
                {
                    ThrowError("Length");
                }
                this.length = value;
            }
        }

        private double Width
        {
            set
            {
                if (value <= 0)
                {
                    ThrowError("Width");
                }
                this.width = value;
            }
        }

        private double Height
        {
            set
            {
                if (value <= 0)
                {
                    ThrowError("Height");
                }
                this.height = value;
            }
        }

        private void ThrowError(string element)
        {
            throw new ArgumentException($"{element} cannot be zero or negative. ");
        }

        public double GetVolume()
        {
            return this.width * this.height * this.length;
        }

        public double GetLiteralSurfaceArea()
        {
            return 2 * (this.height * this.length + this.height * this.width);
        }

        public double GetSurafaceArea()
        {
            return 2 * this.height * (this.width + this.length) + 2 * this.width * this.length;
        }
    }
}
