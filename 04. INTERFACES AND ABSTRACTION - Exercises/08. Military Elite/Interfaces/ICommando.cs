using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface ICommando
    {
        List<Mission> Missions { get; }
    }
}
