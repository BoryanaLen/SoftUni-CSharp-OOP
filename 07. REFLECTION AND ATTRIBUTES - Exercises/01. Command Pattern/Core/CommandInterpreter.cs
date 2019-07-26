
using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string commandFix = "Command";

        public string Read(string inputLine)
        {
            string[] inputInfo = inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            string commandName = inputInfo[0] + commandFix;

            string[] commandArgs = inputInfo.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type[] types = assembly.GetTypes();

            Type typeToCreate = types.FirstOrDefault(t => t.Name == commandName);

            if(typeToCreate == null)
            {
                throw new InvalidOperationException("Invalid command type!");
            }

            Object instance = Activator.CreateInstance(typeToCreate);

            ICommand command = (ICommand)instance;

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
