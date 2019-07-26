using ExercisesSOLID.Contracts;
using ExercisesSOLID.Enumerations;
using ExercisesSOLID.Exceptions;
using ExercisesSOLID.Models.Errors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ExercisesSOLID.Factories
{
    public class ErrorFactory
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";

        public IError GetError(string dateString, string levelString, string message)
        {
            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelString, out level);

            if (!hasParsed)
            {
                throw new InvalidLevelTypeException();
            }

            DateTime dateTame;

            try
            {
                dateTame = DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture);
            }
            catch(Exception exp)
            {
                throw new InvalidDateFormatException();
            }

            return new Error(dateTame, message, level);
        }
    }
}
