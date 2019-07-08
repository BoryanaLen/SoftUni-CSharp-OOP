using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;

        private double width;

        private double height;

        protected double Length
        {
            get { return this.length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                length = value;
            }
        }

        protected double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                width = value;
            }
        }

        protected double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                height = value;
            }
        }

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        //2lw + 2lh + 2wh
        public double CalculateSurfaceArea()
        {
            return (2 * Length * Width + 2 * length * height + 2 * width * height);
        }

        //2lh + 2wh
        public double CalculateLateralSurfaceArea()
        {
            return (2 * Length * Height + 2 * Width * Height);
        }

        //lwh
        public double CalculateVolume()
        {
            return Length * Width * Height;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {this.CalculateSurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {this.CalculateLateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {this.CalculateVolume():F2}");

            return sb.ToString().TrimEnd();
        }
    }
}
