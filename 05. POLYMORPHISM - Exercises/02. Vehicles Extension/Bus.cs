using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double increseFuelConsumation = 1.4;

        public Bus(double fuelQuantity, double fuelConsumtion, double tankCapacity) 
            : base(fuelQuantity, fuelConsumtion, tankCapacity)
        {
            this.FuelConsumption = fuelConsumtion + increseFuelConsumation;
        }

        public void DriveEmpty(double distance)
        {
            this.FuelConsumption -= 1.4;

            this.Drive(distance);
        }
    }
}
