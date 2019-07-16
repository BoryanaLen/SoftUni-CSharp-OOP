using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public double TankCapacity { get; set; }

        public Vehicle(double fuelQuantity, double fuelConsumtion, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                this.FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }

            this.FuelConsumption = fuelConsumtion;

            this.TankCapacity = tankCapacity;
        }

        public virtual void Drive(double distance)
        {
            double neededFuelQuantity = distance * FuelConsumption;

            if (FuelQuantity >= neededFuelQuantity)
            {
                this.FuelQuantity -= neededFuelQuantity;

                throw new ArgumentException($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double amountOfFuel)
        {
            if (amountOfFuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + amountOfFuel > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amountOfFuel} fuel in the tank");
            }

            this.FuelQuantity += amountOfFuel;
        }
    }
}
