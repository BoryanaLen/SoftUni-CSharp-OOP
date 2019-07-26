using ExercisesSOLID.Contracts;
using ExercisesSOLID.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesSOLID.Models.Errors
{
    public class Error : IError
    {
        public Error(DateTime dateTime, string message, Level level = Level.INFO)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.Level = level;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public Level Level { get; }
    }
}
