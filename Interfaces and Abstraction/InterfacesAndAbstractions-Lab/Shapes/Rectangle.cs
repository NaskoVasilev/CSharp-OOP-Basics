using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void Draw()
        {
            this.PrintBorderLine();
            this.PrintMiddlePart();
            this.PrintBorderLine();
        }

        private void PrintBorderLine()
        {
            Console.WriteLine(new string('*', this.Width));
        }

        private void PrintMiddlePart()
        {
            for (int i = 0; i < this.Height - 2; i++)
            {
                Console.WriteLine($"*{new string(' ', this.Width - 2)}*");
            }
        }
    }
}
