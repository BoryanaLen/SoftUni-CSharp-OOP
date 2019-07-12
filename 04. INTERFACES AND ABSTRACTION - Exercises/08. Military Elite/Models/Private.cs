using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Private : IPrivate
    {
        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public decimal Salary { get; private set; }

        public Private(int id, string firstName, string lastName, decimal salary)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
        }

        public override string ToString()
        {
            return ($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
        }
    }
}
