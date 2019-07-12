using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface IPhoneBrowse
    {
        List<string> Sites { get; }
        void Browse();
    }
}
