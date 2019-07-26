using P02.Graphic_Editor.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Square : IShape, IDrawable
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine("I'm Square");
        }

        public bool IsMatch(IShape shape)
        {
            if (shape is Square)
            {
                return true;
            }

            return false;
        }
    }
}
