using System;
using System.Collections.Generic;
using System.Text;

namespace P02_CarsSalesman
{
    public class Engine
    {
        private const string offset = "  ";

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = -1;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement) : this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency) : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
        {
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"  {Model}:");
            sb.AppendLine($"    Power: {Power}");

            if(this.Displacement == -1)
            {
                sb.AppendLine($"    Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"    Displacement: {Displacement}");
            }
            
            sb.AppendLine($"    Efficiency: {Efficiency}");

            return sb.ToString().TrimEnd();
        }

    }
}
