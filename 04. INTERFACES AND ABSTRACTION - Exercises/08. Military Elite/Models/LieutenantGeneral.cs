using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public List<Private> Privates { get; private set; }

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id,firstName, lastName, salary)
        {
            this.Privates = new List<Private>();
        }

        public void AddPrivate(Private newPrivate)
        {
            this.Privates.Add(newPrivate);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: { FirstName} { LastName} Id: {Id} Salary: {Salary:F2}");
            sb.AppendLine($"Privates:");
            foreach(var element in Privates)
            {
                sb.AppendLine("  " + element.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
