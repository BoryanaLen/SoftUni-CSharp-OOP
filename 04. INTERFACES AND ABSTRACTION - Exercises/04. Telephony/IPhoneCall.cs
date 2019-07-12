﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface IPhoneCall
    {
        List<string> Numbers { get; }
        void Call();
    }
}
