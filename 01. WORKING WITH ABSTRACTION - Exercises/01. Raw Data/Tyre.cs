using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Tyre
    {
        public double Pressure { get; set; }
        public int Age { get; set; }

        public Tyre(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }
    }
}
