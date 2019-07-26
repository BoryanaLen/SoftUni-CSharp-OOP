using ExercisesSOLID.Contracts;
using ExercisesSOLID.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExercisesSOLID.Core
{
    public class Engine
    {
        private ILogger logger;

        private ErrorFactory errorFactory;

        private Engine()
        {
            this.errorFactory = new ErrorFactory();
        }

        public Engine(ILogger logger) : this()
        {
            this.logger = logger;
        }

        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();

                if(command == "END")
                {
                    break;
                }

                string[] errorArgs = command.Split("|").ToArray();

                string level = errorArgs[0];
                string date = errorArgs[1];
                string message = errorArgs[2];

                try
                {
                    IError error = this.errorFactory.GetError(date, level, message);

                    this.logger.Log(error);
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp);
                }
            }

            Console.WriteLine(this.logger.ToString());
        }
    }
}
