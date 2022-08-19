using System;
using System.Collections.Generic;

#nullable disable

namespace hotelRepository.Models
{
    public partial class Reservation
    {
        public int ReservationId { get; set; }
        public int? CustomerId { get; set; }
        public int? RoomId { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int? HotelCode { get; set; }
        public decimal? Amount { get; set; }
    }
}
