using P02.Graphic_Editor.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Circle : IShape, IDrawable
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine("I'm Circle");
        }

        public bool IsMatch(IShape shape)
        {
            if(shape is Circle)
            {
                return true;
            }

            return false;
        }
    }
}
