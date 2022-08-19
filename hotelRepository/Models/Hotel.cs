using System;
using System.Collections.Generic;

#nullable disable

namespace hotelRepository.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            Employees = new HashSet<Employee>();
            RoomInformations = new HashSet<RoomInformation>();
        }

        public int HotelCode { get; set; }
        public string HotelName { get; set; }
        public string Address { get; set; }
        public int? Postcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNo { get; set; }
        public decimal? StarRating { get; set; }
        public string ClassName { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<RoomInformation> RoomInformations { get; set; }
    }
}
