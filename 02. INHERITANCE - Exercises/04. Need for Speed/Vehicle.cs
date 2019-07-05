using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        private const double DefaultFuelConsumption = 1.25;

        public virtual double FuelConsumption => DefaultFuelConsumption;

        public Vehicle(int horsePower, double fuel)
        {
            this.Fuel = fuel;
            this.HorsePower = horsePower;
        }

        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * this.FuelConsumption;
        }
    }
}
