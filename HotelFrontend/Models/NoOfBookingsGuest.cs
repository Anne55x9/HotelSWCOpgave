namespace HotelFrontend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class NoOfBookingsGuest
    {

        public int Guest_No { get; set; }

        public string Name { get; set; }

        public int? BookingCount { get; set; }

        public override string ToString()
        {
            return "Gæste Nr: " + Guest_No + " Navn: " + Name + " Bookings: " + BookingCount;
        }
    }
}
