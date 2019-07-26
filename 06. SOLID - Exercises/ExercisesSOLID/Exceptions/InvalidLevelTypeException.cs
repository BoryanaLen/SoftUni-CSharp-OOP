using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesSOLID.Exceptions
{
    public class InvalidLevelTypeException : Exception
    {
        private const string excMessage = "Invalid level Type!";

        public InvalidLevelTypeException() : base(excMessage)
        {

        }

        public InvalidLevelTypeException(string message) : base(message)
        {

        }
    }
}
