using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engine
    {
        private List<Private> privets;

        public Engine()
        {
            privets = new List<Private>();
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
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries )
                    .ToList();

                string type = inputInfo[0];
                int id = int.Parse(inputInfo[1]);
                string firstName = inputInfo[2];
                string lastName = inputInfo[3];

                if (type == "Private")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);

                    Private currentSoldier = new Private(id, firstName, lastName, salary);

                    privets.Add(currentSoldier);

                    Console.WriteLine(currentSoldier);
                }
                else if(type == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);

                    int [] paramsPrivate = inputInfo.Skip(5).Select(int.Parse).ToArray();

                    LieutenantGeneral currentSoldier = new LieutenantGeneral(id, firstName, lastName, salary);

                    foreach(int number in paramsPrivate)
                    {
                        Private found = privets.Where(x => x.Id == number).FirstOrDefault();

                        if (found != null)
                        {
                            currentSoldier.AddPrivate(found);
                        }
                    }

                    Console.WriteLine(currentSoldier);
                }
                else if(type == "Engineer")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);

                    if(Enum.TryParse<Corp>(inputInfo[5],out Corp result))
                    {  
                        Engineer currentSoldier = new Engineer(id, firstName, lastName, salary, result);

                        string[] repairsInfo = inputInfo.Skip(6).ToArray();

                        for (int i = 0; i < repairsInfo.Count(); i += 2)
                        {
                            string part = repairsInfo[i];
                            int hours = int.Parse(repairsInfo[i + 1]);
                            currentSoldier.Repairs.Add(new Repair(part, hours));
                        }

                        Console.WriteLine(currentSoldier);
                    }
                }
                else if(type == "Commando")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);

                    if (Enum.TryParse<Corp>(inputInfo[5], out Corp result))
                    {                      
                        Commando currentSoldier = new Commando(id, firstName, lastName, salary, result);

                        string[] missionsInfo = inputInfo.Skip(6).ToArray();

                        for (int i = 0; i < missionsInfo.Count(); i += 2)
                        {
                            string name = missionsInfo[i];

                            if (Enum.TryParse<State>(missionsInfo[i + 1], out State resultState))
                            {
                                Mission newMission = new Mission(name, resultState);

                                currentSoldier.Missions.Add(newMission);
                            }
                        }

                        Console.WriteLine(currentSoldier);
                    }
                }
                else if (type == "Spy")
                {
                    int codeNumber = int.Parse(inputInfo[4]);

                    Spy currentSoldier = new Spy(id, firstName, lastName, codeNumber);

                    Console.WriteLine(currentSoldier);
                }
            }
        }
    }
}
