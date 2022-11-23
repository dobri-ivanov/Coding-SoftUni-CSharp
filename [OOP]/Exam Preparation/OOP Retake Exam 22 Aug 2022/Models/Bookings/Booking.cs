using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        private int bookingNumber;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            this.bookingNumber = bookingNumber;
        }

        public IRoom Room {get; private set;}

        public int ResidenceDuration
        {
            get { return this.residenceDuration; }
            private set
            {
                if (value <= 0) throw new ArgumentException(string.Format(ExceptionMessages.DurationZeroOrLess));
                this.residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get { return this.adultsCount; }
            private set
            {
                if (value < 1) throw new ArgumentException(string.Format(ExceptionMessages.AdultsZeroOrLess));
                this.adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get { return this.childrenCount; }
            private set
            {
                if (value < 0) throw new ArgumentException(string.Format(ExceptionMessages.ChildrenNegative));
                this.childrenCount = value;
            }
        }

        public int BookingNumber
        {
            get { return this.bookingNumber; }
        }
        public double TotalPaid()
        {
            return Math.Round(ResidenceDuration * this.Room.PricePerNight, 2);
        }
        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booking Number: {BookingNumber}");
            sb.AppendLine($"Room type: {this.Room.GetType().Name}");
            sb.AppendLine($"Adults: {AdultsCount}Children: {ChildrenCount}");
            sb.AppendLine($"Total amount paid: {TotalPaid()}");
            return sb.ToString().TrimEnd();
        }
    }
}
