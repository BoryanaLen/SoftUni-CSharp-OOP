﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public enum Corp
    {
        Airforces,
        Marines
    }
    public interface ISpecialisedSoldier
    {
        Corp Corp { get; }
    }
}
