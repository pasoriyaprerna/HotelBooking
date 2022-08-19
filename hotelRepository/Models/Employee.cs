using System;
using System.Collections.Generic;

#nullable disable

namespace hotelRepository.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string JobDepartment { get; set; }
        public string Address { get; set; }
        public string ContactAdd { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? HotelCode { get; set; }

        public virtual Hotel HotelCodeNavigation { get; set; }
    }
}
