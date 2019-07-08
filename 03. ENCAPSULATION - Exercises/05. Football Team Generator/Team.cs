using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;

        private List<Player> players;

        public int Rating
        {
            get
            {
                if (players.Count > 0)
                {
                    return (int)players.Select(x => x.skillLevel).Average();
                }

                return 0;
            }
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = players.Where(x => x.Name == playerName).FirstOrDefault();

            if (playerToRemove != null)
            {
                players.Remove(playerToRemove);
            }
            else
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }
        }
    }
}
