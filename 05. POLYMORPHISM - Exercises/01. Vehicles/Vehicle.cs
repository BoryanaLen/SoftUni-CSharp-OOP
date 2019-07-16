using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public virtual void Drive(double distance)
        {
            double neededFuelQuantity = distance * FuelConsumption;

            if (FuelQuantity >= neededFuelQuantity)
            {
                this.FuelQuantity -= neededFuelQuantity;

                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double amountOfFuel)
        {
            this.FuelQuantity += amountOfFuel;
        }
    }
}
