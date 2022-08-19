using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotelModels
{
   public class hotelInfo
    {
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

    }
}
