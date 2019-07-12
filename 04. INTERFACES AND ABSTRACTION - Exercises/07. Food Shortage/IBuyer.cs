using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IBuyer : IIdentical
    {
        int Food { get; }

        void BuyFood();
    }
}
