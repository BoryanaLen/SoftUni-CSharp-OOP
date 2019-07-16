using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double increseFuelConsumation = 0.9;

        public Car(double fuelQuantity, double fuelConsumation)
        {
            this.FuelQuantity = fuelQuantity;

            this.FuelConsumption = fuelConsumation + increseFuelConsumation;
        }
    }
}
