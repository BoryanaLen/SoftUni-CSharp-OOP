using PlayersAndMonsters.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private ManagerController managerController;

        public Engine()
        {
            this.managerController = new ManagerController();
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    if(input == "Exit")
                    {
                        break;
                    }

                    List<string> inputInfo = input.Split().ToList();

                    string command = inputInfo[0];

                    string result = string.Empty;

                    if(command == "AddPlayer")
                    {
                        string type = inputInfo[1];
                        string name = inputInfo[2];

                        result = this.managerController.AddPlayer(type,name);
                    }
                    else if (command == "AddCard")
                    {
                        string type = inputInfo[1];
                        string name = inputInfo[2];

                        result = this.managerController.AddCard(type,name);
                    }
                    else if (command == "AddPlayerCard")
                    {
                        string username = inputInfo[1];
                        string cardname = inputInfo[2];

                        result = this.managerController.AddPlayerCard(username,cardname);
                    }
                    else if (command == "Fight")
                    {
                        string attacker = inputInfo[1];
                        string enemy = inputInfo[2];

                        result = this.managerController.Fight(attacker, enemy);
                    }
                    else if (command == "Report")
                    {
                        result = this.managerController.Report();
                    }

                    Console.WriteLine(result);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
