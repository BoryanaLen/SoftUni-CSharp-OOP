using ExercisesSOLID.Contracts;
using ExercisesSOLID.Exceptions;
using ExercisesSOLID.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ExercisesSOLID.Factories
{
    public class LayoutFactory
    {
        //public ILayout GetLayout(string type)
        //{
        //    ILayout layout;

        //    if(type == "SimpleLayout")
        //    {
        //        layout = new SimpleLayout();
        //    }
        //    else if(type == "XmlLayout")
        //    {
        //        layout = new Xmllayout();
        //    }
        //    else
        //    {
        //        throw new InvalidLayoutTypeException();
        //    }

        //    return layout;
        //}


        public ILayout GetLayout(string type)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type typeToCreate = assembly
                .GetTypes()
                .FirstOrDefault(c => c.Name == type);

            if(typeToCreate == null)
            {
                throw new InvalidLayoutTypeException();
            }

            ILayout layout = (ILayout)Activator.CreateInstance(typeToCreate);

            return layout;
        }
    }
}
