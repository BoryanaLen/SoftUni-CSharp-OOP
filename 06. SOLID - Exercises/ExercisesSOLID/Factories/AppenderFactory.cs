using ExercisesSOLID.Contracts;
using ExercisesSOLID.Enumerations;
using ExercisesSOLID.Exceptions;
using ExercisesSOLID.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ExercisesSOLID.Factories
{
    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }

        public IAppender GetAppender(string appenderType, string layoutType, string levelString)
        {
            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelString, out level);

            if (!hasParsed)
            {
                throw new InvalidLevelTypeException();
            }

            ILayout layout = this.layoutFactory.GetLayout(layoutType);

            Assembly assembly = Assembly.GetExecutingAssembly();

            Type type = assembly
                .GetTypes()
                .FirstOrDefault(c => c.Name == appenderType);

            if (type== null)
            {
                throw new InvalidAppenderTypeException();
            }

            object[] args = new object[]
            {
                layout,
                level
            };

            IAppender appender = (IAppender)Activator.CreateInstance(type, args);

            return appender;
        }
    }
}
