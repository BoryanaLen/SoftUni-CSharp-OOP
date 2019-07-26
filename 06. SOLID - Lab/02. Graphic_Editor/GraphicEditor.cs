using P02.Graphic_Editor.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        private List<IDrawable> drawers = new List<IDrawable>()
        {
            new Circle(),
            new Rectangle(),
            new Square()
        };
        public void DrawShape(IShape shape)
        {
            drawers.First(x => x.IsMatch(shape)).Draw(shape);
        }
    }
}
