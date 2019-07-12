using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : Private, ISpecialisedSoldier, IEngineer
    {
        public Corp Corp { get; private set; }

        public List<Repair> Repairs { get; private set; }

        public Engineer(int id, string firstName, string lastName, decimal salary, Corp corp)
            : base(id, firstName, lastName, salary)
        {
            this.Corp = corp;
            this.Repairs = new List<Repair>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: { FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
            sb.AppendLine($"Corps: {Corp}");
            sb.AppendLine("Repairs:");
            foreach (var element in Repairs)
            {
                sb.AppendLine("  " + element.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
