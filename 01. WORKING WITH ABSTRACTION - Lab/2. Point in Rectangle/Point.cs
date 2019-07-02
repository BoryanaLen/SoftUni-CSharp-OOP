using System;
using System.Collections.Generic;
using System.Text;

namespace PointRectangle
{
    public class Point
    {
        public double X { get; private set; }

        public double Y { get; private set; }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}

