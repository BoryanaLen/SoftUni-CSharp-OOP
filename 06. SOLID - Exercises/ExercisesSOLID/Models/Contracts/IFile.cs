using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesSOLID.Contracts
{
    public interface IFile
    {
        string Path { get; }
        ulong Size { get; }
        string Write(ILayout layout, IError error);
    }
}
