using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesSOLID.Exceptions
{
    public class InvalidAppenderTypeException : Exception
    {
        private const string excMessage = "Invalid DateTime Format!";

        public InvalidAppenderTypeException() : base(excMessage)
        {
        }

        public InvalidAppenderTypeException(string message) : base(message)
        {
        }
    }
}
