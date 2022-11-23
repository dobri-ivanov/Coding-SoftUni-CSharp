using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public class Room : IRoom
    {

        private int bedCapacity;
        private double pricePerNight = 0;

        public Room(int bedCapacity)
        {
            this.BedCapacity = bedCapacity;
        }
        public int BedCapacity
        {
            get { return this.bedCapacity; }
            private set { this.bedCapacity = value; }
        }
        public double PricePerNight
        {
            get { return this.pricePerNight; }
            private set
            {
                if (value < 0) throw new ArgumentException(string.Format(ExceptionMessages.PricePerNightNegative));
                this.pricePerNight = value;
            }
        }
        public void SetPrice(double price)
        {
            this.PricePerNight = price;
        }
    }
}
