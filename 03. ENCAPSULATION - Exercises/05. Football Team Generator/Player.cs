using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public int Shooting
        {
            get => this.shooting;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Shooting should be between 0 and 100.");
                }

                this.shooting = value;
            }
        }
        public int Passing
        {
            get => this.passing;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Passing should be between 0 and 100.");
                }

                this.passing = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Dribble should be between 0 and 100.");
                }

                this.dribble = value;
            }
        }
        public int Sprint
        {
            get => this.sprint;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Sprint should be between 0 and 100.");
                }

                this.sprint = value;
            }
        }
        public int Endurance
        {
            get => this.endurance;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Endurance should be between 0 and 100.");
                }

                this.endurance = value;
            }
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public Player(string name, int endurance,int sprint,int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        internal int skillLevel
        {
            get
            {
                return (int)Math.Round((this.Endurance + this.Dribble + this.Sprint + this.Passing + this.Shooting) / 5.0);
            }
        }
    }
}
