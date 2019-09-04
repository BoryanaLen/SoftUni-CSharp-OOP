using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double initialHealthPoints = 200;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints + 50, defensePoints - 25, initialHealthPoints)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if(AggressiveMode == false)
            {
                this.AggressiveMode = true;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else
            {
                this.AggressiveMode = false;
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            string result = string.Empty;

            if(this.AggressiveMode == true)
            {
                result = " *Aggressive: ON";
            }
            else
            {
                result = " *Aggressive: OFF";
            }

            return base.ToString() + Environment.NewLine + result;
        }
    }
}
