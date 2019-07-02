using System;
using System.Collections.Generic;
using System.Text;

namespace PointRectangle
{
    public class Rectangle
    {
        private Point topLeftPoint;

        private Point bottomRightPoint;

        public Point TopLeftPoint
        {
            get { return this.topLeftPoint; }
            set { this.topLeftPoint = value; }
        }

        public Point BottomRightPoint
        {
            get { return this.bottomRightPoint; }
            set { this.bottomRightPoint = value; }
        }

        public Rectangle(Point topLeftPoint, Point bottomRightPoint)
        {
            TopLeftPoint = topLeftPoint;

            BottomRightPoint = bottomRightPoint;
        }

        public bool Contains(Point point)
        {
            bool result = false;

            if (point.X >= topLeftPoint.X && point.X <= bottomRightPoint.X
                && point.Y >= topLeftPoint.Y && point.Y <= bottomRightPoint.Y)
            {
                result = true;
            }

            return result;
        }
    }
}
