using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : Private, ISpecialisedSoldier, ICommando
    {
        public Corp Corp { get; private set; }

        public List<Mission> Missions { get; private set; }

        public Commando(int id, string firstName, string lastName, decimal salary, Corp corp)
            : base(id, firstName, lastName, salary)
        {
            this.Corp = corp;
            this.Missions = new List<Mission>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: { FirstName} { LastName} Id: {Id} Salary: {this.Salary:F2}");
            sb.AppendLine($"Corps: {Corp}");
            sb.AppendLine("Missions:");
            foreach (var element in Missions)
            {               
                sb.AppendLine("  " + element.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
