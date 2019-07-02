using System;
using System.Collections.Generic;
using System.Linq;

namespace PointRectangle
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<double> dimensions = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(double.Parse)
                 .ToList();

            double x1 = dimensions[0];
            double y1 = dimensions[1];
            double x2 = dimensions[2];
            double y2 = dimensions[3];

            Rectangle rectangle = new Rectangle(new Point(x1, y1), new Point(x2, y2));

            int numberLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberLines; i++)
            {
                List<int> pointCoordinates = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

                Point currentPoint = new Point(pointCoordinates[0], pointCoordinates[1]);

                Console.WriteLine(rectangle.Contains(currentPoint));
            }
        }
    }
}
