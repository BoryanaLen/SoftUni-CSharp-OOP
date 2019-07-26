using ExercisesSOLID.Contracts;
using ExercisesSOLID.Enumerations;
using ExercisesSOLID.Models.IOManagement;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ExercisesSOLID.Models
{
    public class LogFile :DateFormat, IFile
    {
        private const string currentDirectory = "\\logs\\";

        private const string currentFile = "log.txt";

        private string currentPath;

        private IIOManager IOManager;

        public LogFile()
        {
            this.IOManager = new IOManager(currentDirectory, currentFile);
            this.currentPath = this.IOManager.GetCurrentPath();
            this.IOManager.EnsureDirectoryAndFileExist();
            this.Path = currentPath + currentDirectory + currentFile;
        }

        public string Path { get; }

        public ulong Size => GetFileSize();

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formatedMessage = String.Format(format
                , dateTime.ToString(this.CurrentDateFormat, CultureInfo.InvariantCulture),
                level.ToString(),
                message);

            return formatedMessage;
        }

        private ulong GetFileSize()
        {
            string text = File.ReadAllText(this.Path);

            ulong size = (ulong)text
                .ToCharArray()
                .Where(c => Char.IsLetter(c))
                .Sum(c => (int)c);

            return size;
        }
    }
}
