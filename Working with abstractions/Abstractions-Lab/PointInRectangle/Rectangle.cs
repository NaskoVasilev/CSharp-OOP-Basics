namespace PointInRectangle
{
    class Rectangle
    {
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public Rectangle(Point topLeft, Point bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public bool Contains(Point point)
        {
            return TopLeft.X <= point.X
                && BottomRight.X >= point.X
                && TopLeft.Y <= point.Y
                && BottomRight.Y >= point.Y;
        }
    }
}
