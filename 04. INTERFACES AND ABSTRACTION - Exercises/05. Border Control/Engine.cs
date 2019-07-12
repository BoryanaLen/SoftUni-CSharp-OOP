using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl
{
    public class Engine
    {
        private List<IIdentical> society;

        public Engine()
        {
            this.society = new List<IIdentical>();
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

                if(inputInfo.Count == 3)
                {
                    string name = inputInfo[0];
                    int age = int.Parse(inputInfo[1]);
                    string id = inputInfo[2];

                    Citizen citizen = new Citizen(name, age, id);
                    society.Add(citizen);
                }
                else if(inputInfo.Count == 2)
                {
                    string model = inputInfo[0];
                    string id = inputInfo[1];

                    Robot robot = new Robot(model, id);
                    society.Add(robot);
                }
            }

            string numberEnd = Console.ReadLine();

            foreach(var element in society)
            {
                if (element.Id.EndsWith(numberEnd))
                {
                    Console.WriteLine(element.Id);
                }
            }
        }
    }
}
