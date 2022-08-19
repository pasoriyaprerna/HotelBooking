using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotelRepository.Models
{
  public  class summary
    {
        public int ReservationId { get; set; }
        public int? CustomerId { get; set; }
        public int? RoomId { get; set; }
   
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
       
        public int? HotelCode { get; set; }
        public decimal? Amount { get; set; }

        public string Custfname { get; set; }
        public string Custlname { get; set; }
        public string EmailAddress { get; set; }
    }
}
