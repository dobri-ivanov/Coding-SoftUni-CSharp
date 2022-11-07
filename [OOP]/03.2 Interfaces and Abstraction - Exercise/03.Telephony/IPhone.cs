using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public interface ISmartPhone : IStationaryPhone
    {
        public void Browse(string url);
    }
}
