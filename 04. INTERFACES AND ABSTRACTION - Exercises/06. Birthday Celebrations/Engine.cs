using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl
{
    public class Engine
    {
        private List<IIdentical> citizensAndPets;

        public Engine()
        {
            this.citizensAndPets = new List<IIdentical>();
        }
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
                    .Split()
                    .ToList();

                if(inputInfo.Count == 5)
                {
                    string name = inputInfo[1];
                    int age = int.Parse(inputInfo[2]);
                    string id = inputInfo[3];
                    string birthdate = inputInfo[4];

                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    citizensAndPets.Add(citizen);
                }
                else if(inputInfo.Count == 3 && inputInfo[0] == "Pet")
                {
                    string name = inputInfo[1];
                    string birthdate = inputInfo[2];

                    Pet pet = new Pet(name, birthdate);
                    citizensAndPets.Add(pet);
                }
            }

            string numberEnd = Console.ReadLine();

            foreach(var element in citizensAndPets)
            {
                if (element.Birthdate.EndsWith(numberEnd))
                {
                    Console.WriteLine(element.Birthdate);
                }
            }
        }
    }
}
