using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {

        private const double increseFuelConsumation = 1.6;

        private const double percentOfFuelKeep = 95;
        public Truck(double fuelQuantity, double fuelConsumation) 
        {
            this.FuelQuantity = fuelQuantity;

            this.FuelConsumption = fuelConsumation + increseFuelConsumation;
        }

        public override void Refuel(double amountOfFuel)
        {
            this.FuelQuantity += amountOfFuel * percentOfFuelKeep / 100;
        }
    }
}
