using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {

        private const double increseFuelConsumation = 1.6;

        private const double percentOfFuelKeep = 95;

        public Truck(double fuelQuantity, double fuelConsumtion, double tankCapacity)
            : base(fuelQuantity, fuelConsumtion, tankCapacity)
        {
            this.FuelConsumption = fuelConsumtion + increseFuelConsumation;
        }

        public override void Refuel(double amountOfFuel)
        {
            if (amountOfFuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + amountOfFuel > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amountOfFuel} fuel in the tank");
            }

            this.FuelQuantity += amountOfFuel * percentOfFuelKeep / 100;
        }
    }
}
