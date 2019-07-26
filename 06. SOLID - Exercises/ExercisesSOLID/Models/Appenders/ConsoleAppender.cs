using ExercisesSOLID.Contracts;
using ExercisesSOLID.Enumerations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ExercisesSOLID.Models
{
    class ConsoleAppender : DateFormat, IAppender
    {
        private int messagesAppended;

        public ConsoleAppender()
        {
            this.messagesAppended = 0;
        }
        public ConsoleAppender(ILayout layout, Level level) : this()
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formatedMessage = String.Format(format
                , dateTime.ToString(this.CurrentDateFormat, CultureInfo.InvariantCulture),
                level.ToString(),
                message);

            Console.WriteLine(formatedMessage);
            this.messagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended}";
        }
    }
}
