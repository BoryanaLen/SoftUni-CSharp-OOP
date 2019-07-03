using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Engine
    {
        private Dictionary<string, List<string>> doctors;

        private Dictionary<string, List<string>> departments;

        public Engine()
        {
            this.doctors = new Dictionary<string, List<string>>();

            this.departments = new Dictionary<string, List<string>>();
        }

        public void Run ()
        {
            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] inputArgs = command.Split();

                var department = inputArgs[0];
                var firstName = inputArgs[1];
                var secondName = inputArgs[2];
                var patient = inputArgs[3];

                var fullName = firstName + " " + secondName;

                if (AddPatientToDepartment(department, patient))
                {
                    AddPatientToDoctor(fullName, patient);
                }

                command = Console.ReadLine();
            }

            string commandOutput = Console.ReadLine();

            while (commandOutput != "End")
            {
                this.Print(commandOutput);

                commandOutput = Console.ReadLine();
            }
        }

        private void AddPatientToDoctor(string fullName, string patient)
        {
            if (doctors.ContainsKey(fullName))
            {
                doctors[fullName].Add(patient);
            }
            else
            {
                doctors.Add(fullName, new List<string>() { patient });
            }
        }

        private bool AddPatientToDepartment(string department, string patient)
        {
            bool result = false;

            if (departments.ContainsKey(department))
            {
                if (departments[department].Count < 60) 
                {
                    result = true;

                    departments[department].Add(patient);

                }
            }
            else
            {
                departments.Add(department, new List<string>() { patient });

                result = true;
            }

            return result;
        }

        private void Print(string commandOutput)
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
        }
    }
}
