using MortalEngines.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private MachinesManager machineManager;

        public Engine()
        {
            this.machineManager = new MachinesManager();
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    if (input == "Quit")
                    {
                        break;
                    }

                    List<string> commandInfo = input
                        .Split()
                        .ToList();

                    string commandType = commandInfo[0];

                    List<string> parameters = commandInfo.Skip(1).ToList();

                    if (commandType == "HirePilot")
                    {
                        Console.WriteLine(machineManager.HirePilot(parameters[0]));
                    }
                    else if (commandType == "PilotReport")
                    {
                        Console.WriteLine(machineManager.PilotReport(parameters[0]));
                    }
                    else if (commandType == "ManufactureTank")
                    {
                        Console.WriteLine(machineManager.ManufactureTank(parameters[0], double.Parse(parameters[1]), double.Parse(parameters[2])));
                    }
                    else if (commandType == "ManufactureFighter")
                    {
                        Console.WriteLine(machineManager.ManufactureFighter(parameters[0], double.Parse(parameters[1]), double.Parse(parameters[2])));
                    }
                    else if (commandType == "MachineReport")
                    {
                        Console.WriteLine(machineManager.MachineReport(parameters[0]));
                    }
                    else if (commandType == "AggressiveMode")
                    {
                        Console.WriteLine(machineManager.ToggleFighterAggressiveMode(parameters[0]));
                    }
                    else if (commandType == "DefenseMode")
                    {
                        Console.WriteLine(machineManager.ToggleTankDefenseMode(parameters[0]));
                    }
                    else if (commandType == "Engage")
                    {
                        Console.WriteLine(machineManager.EngageMachine(parameters[0], parameters[1]));
                    }
                    else if (commandType == "Attack")
                    {
                        Console.WriteLine(machineManager.AttackMachines(parameters[0], parameters[1]));
                    }

                }
                catch (Exception exp)
                {
                    Console.WriteLine($"Error: {exp.Message}");
                    continue;
                }
            }
        }
    }
}
