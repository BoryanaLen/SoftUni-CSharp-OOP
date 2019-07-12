using ExplicitInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExplicitInterfaces.Models
{
    public class Engine
    {
        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if(input == "End")
                {
                    break;
                }

                List<string> inputInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string name = inputInfo[0];
                string country = inputInfo[1];
                int age = int.Parse(inputInfo[2]);

                IPerson citizen = new Citizen(name, country, age);

                Console.WriteLine(citizen.GetName());

                IResident citizenResident = new Citizen(name, country, age);

                Console.WriteLine(citizenResident.GetName());

            }
        }
    }
}
