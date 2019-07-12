using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFerrari
{
    public class Ferrari : ICar
    {
        public string Model { get; private set; }

        public string DriverName { get; private set; }

        public Ferrari(string driverName)
        {
            this.Model = "488-Spider";
            this.DriverName = driverName;
        }

        public string PushTheGasPedal()
        {
           return "Gas!";
        }

        public string UseBrakes()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            return ($"{Model}/{this.UseBrakes()}/{this.PushTheGasPedal()}/{DriverName}");
        }
    }
}
