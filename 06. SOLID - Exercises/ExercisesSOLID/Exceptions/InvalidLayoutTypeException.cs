using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesSOLID.Exceptions
{
    public class InvalidLayoutTypeException : Exception
    {
        private const string excMessage = "Invalid Layout Type!";

        public InvalidLayoutTypeException() : base(excMessage)
        {

        }

        public InvalidLayoutTypeException(string message) : base(message)
        {

        }
    }
}
