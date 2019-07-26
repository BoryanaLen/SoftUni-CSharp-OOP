using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesSOLID.Contracts
{
    public interface IIOManager
    {
        string CurrentDirectoryPath { get; }
        string CurrentFilePath { get; }
        void EnsureDirectoryAndFileExist();
        string GetCurrentPath();
    }
}
