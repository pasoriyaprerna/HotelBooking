using System;
using System.Collections.Generic;

#nullable disable

namespace hotelRepository.Models
{
    public partial class CustInfo
    {
        public int CustomerId { get; set; }
        public string Custfname { get; set; }
        public string Custlname { get; set; }
        public string EmailAddress { get; set; }
    }
}
