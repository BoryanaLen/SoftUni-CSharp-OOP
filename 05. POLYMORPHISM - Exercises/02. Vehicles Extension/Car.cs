using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double increseFuelConsumation = 0.9;

        public Car(double fuelQuantity, double fuelConsumtion, double tankCapacity)
            : base(fuelQuantity, fuelConsumtion, tankCapacity)
        {
            this.FuelConsumption = fuelConsumtion + increseFuelConsumation;
        }
    }
}
