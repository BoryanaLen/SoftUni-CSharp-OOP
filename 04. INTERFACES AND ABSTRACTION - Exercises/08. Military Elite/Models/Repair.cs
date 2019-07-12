using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Repair
    {
        public string Part { get; private set; }
        public int Hours { get; private set; }

        public Repair(string part, int hours)
        {
            this.Part = part;
            this.Hours = hours;
        }

        public override string ToString()
        {
            return $"Part Name: {Part} Hours Worked: {Hours}";
        }
    }
}
