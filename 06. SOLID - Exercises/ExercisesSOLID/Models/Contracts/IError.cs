using ExercisesSOLID.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesSOLID.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }
        string Message { get; }
        Level Level { get; }
    }
}
