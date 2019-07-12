using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFerrari
{
    public interface ICar
    {
        string Model { get; }
        string DriverName { get; }
        string UseBrakes();
        string PushTheGasPedal();
    }
}
