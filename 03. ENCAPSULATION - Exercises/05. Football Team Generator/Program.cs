using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }

                    List<string> inputInfo = input.Split(';').ToList();

                    string command = inputInfo[0];
                    string teamName = inputInfo[1];

                    if (command == "Team")
                    {
                        teams.Add(new Team(teamName));
                    }
                    else if (command == "Add")
                    {
                        //"Add;{TeamName};{PlayerName};{Endurance};{Sprint};{Dribble};{Passing};{Shooting}" 

                        string playerName = inputInfo[2];
                        int endurance = int.Parse(inputInfo[3]);
                        int sprint = int.Parse(inputInfo[4]);
                        int dribble = int.Parse(inputInfo[5]);
                        int passing = int.Parse(inputInfo[6]);
                        int shooting = int.Parse(inputInfo[7]);

                        Team foundTeam = teams.Where(x => x.Name == teamName).FirstOrDefault();

                        if (foundTeam != null)
                        {
                            Player playerToAdd = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                            foundTeam.AddPlayer(playerToAdd);
                        }
                        else
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                    }
                    else if (command == "Remove")
                    {
                        string playerName = inputInfo[2];

                        Team foundTeam = teams.Where(x => x.Name == teamName).FirstOrDefault();

                        if (foundTeam != null)
                        {
                           foundTeam.RemovePlayer(playerName);
                        }
                        else
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                    }
                    else if (command == "Rating")
                    {
                        Team foundTeam = teams.Where(x => x.Name == teamName).FirstOrDefault();

                        if (foundTeam != null)
                        {
                            Console.WriteLine($"{teamName} - {foundTeam.Rating}");
                        }
                        else
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

            }
        }           
    }
}
