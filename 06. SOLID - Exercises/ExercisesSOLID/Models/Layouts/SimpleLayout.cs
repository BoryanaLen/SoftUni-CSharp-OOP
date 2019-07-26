using ExercisesSOLID.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesSOLID.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
