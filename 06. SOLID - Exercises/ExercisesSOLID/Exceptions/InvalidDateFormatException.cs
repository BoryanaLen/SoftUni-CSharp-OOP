using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesSOLID.Exceptions
{
    public class InvalidDateFormatException : Exception
    {
        private const string excMessage = "Invalid Appender Type!";

        public InvalidDateFormatException() : base(excMessage)
        {

        }

        public InvalidDateFormatException(string message) : base(message)
        {

        }

        public InvalidDateFormatException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
