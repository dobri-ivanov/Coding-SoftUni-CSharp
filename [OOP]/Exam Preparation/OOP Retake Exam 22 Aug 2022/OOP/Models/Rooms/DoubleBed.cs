using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public class DoubleBed : Room
    {
        public const int BED_CAPACITY = 2;
        public DoubleBed() : base(BED_CAPACITY)
        {
        }
    }
}
