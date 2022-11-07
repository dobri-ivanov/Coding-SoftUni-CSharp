using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    internal class Smartphone : ISmartPhone
    {
        public void Call(string phoneNumber)
        {
            Console.WriteLine($"Calling... {phoneNumber}");
        }

        public void Browse(string url)
        {
            Console.WriteLine($"Browsing: {url}!");
        }
    }
}
