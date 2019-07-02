using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> departments = new Dictionary<string, List<string>>();


            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] inputRow = command.Split();
                var department = inputRow[0];
                var firstName = inputRow[1];
                var secondName = inputRow[2];
                var patient = inputRow[3];
                var fullName = firstName + " " + secondName;


                if (departments.ContainsKey(department))
                {
                    if (departments[department].Count < 60)
                    {
                        departments[department].Add(patient);

                        if (doctors.ContainsKey(fullName))
                        {
                            doctors[fullName].Add(patient);
                        }
                        else
                        {
                            doctors.Add(fullName, new List<string>() { patient });
                        }
                    }
                }
                else
                {
                    departments.Add(department, new List<string>() { patient });

                    if (doctors.ContainsKey(fullName))
                    {
                        doctors[fullName].Add(patient);
                    }
                    else
                    {
                        doctors.Add(fullName, new List<string>() { patient });
                    }
                }

                command = Console.ReadLine();
            }

            string commandOutput = Console.ReadLine();

            while (commandOutput != "End")
            {
                string[] args = commandOutput.
                    Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string commandType = args[0];

                if (args.Length == 1)
                {
                    if (departments.ContainsKey(commandType))
                    {
                        Console.WriteLine(string.Join("\n", departments[commandType]));
                    }
                }
                else if (args.Length == 2)
                {
                    if (doctors.ContainsKey(commandOutput))
                    {
                        doctors[commandOutput].Sort();

                        Console.WriteLine(string.Join("\n", doctors[commandOutput]));
                    }
                    else
                    {
                        int room = int.Parse(args[1]);

                        List<string> patients = departments[commandType]
                            .Skip((room - 1) * 3)
                            .Take(3).OrderBy(name => name)
                            .ToList();

                        Console.WriteLine(string.Join("\n", patients));
                    }
                }
                

                commandOutput = Console.ReadLine();
            }
        }
    }
}
