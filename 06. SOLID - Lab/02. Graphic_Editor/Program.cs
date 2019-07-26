using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            var circle = new Circle();
            var square = new Square();
            var rectangle = new Rectangle();

            GraphicEditor drawer = new GraphicEditor();
            drawer.DrawShape(circle);
            drawer.DrawShape(square);
            drawer.DrawShape(rectangle);
        }
    }
}
