using ExercisesSOLID.Contracts;
using ExercisesSOLID.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesSOLID.Models
{
    public class FileAppender :DateFormat, IAppender
    {
        private int messagesAppended;

        public FileAppender()
        {
            this.messagesAppended = 0;
            this.File = new LogFile();
        }

        public FileAppender(ILayout layout, Level level) : this()
        {
            this.Layout = layout;
            this.Level = level;
        }

        public FileAppender(ILayout layout, Level level, IFile file) : this()
        {
            this.Layout = layout;
            this.Level = level;
            this.File = file;
        }
        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public IFile File { get; private set; }

        public void Append(IError error)
        {
            string formatedMessage = this.File.Write(this.Layout, error) + Environment.NewLine;

            System.IO.File.AppendAllText(this.File.Path, formatedMessage);

            this.messagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended}, File size {this.File.Size}";
        }
    }
}
