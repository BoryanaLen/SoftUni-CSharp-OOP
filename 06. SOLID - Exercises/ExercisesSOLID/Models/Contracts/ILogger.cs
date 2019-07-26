using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesSOLID.Contracts
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }
        void Log(IError error);
    }
}
