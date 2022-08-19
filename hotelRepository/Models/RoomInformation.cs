using System;
using System.Collections.Generic;

#nullable disable

namespace hotelRepository.Models
{
    public partial class RoomInformation
    {
        public int RoomId { get; set; }
        public int? NumberOfRooms { get; set; }
        public string RoomType { get; set; }
        public decimal? Price { get; set; }
        public int? HotelCode { get; set; }
        public string Availability { get; set; }

        public virtual Hotel HotelCodeNavigation { get; set; }
    }
}
