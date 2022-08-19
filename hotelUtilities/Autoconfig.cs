using AutoMapper;
using hotelModels;
using hotelRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotelUtilities
{
   public class Autoconfig : Profile
    {
        public Autoconfig()
        {
            CreateMap<CustInfo, customerVM>().ReverseMap();

            CreateMap<Hotel, hotelInfo>().ReverseMap();

            CreateMap<information, informationvm>().ReverseMap();
            CreateMap<avail, availvm>().ReverseMap();
            CreateMap<Reservation, reservationvm>().ReverseMap();
            CreateMap<hotelRoom, hotelRoomVM>().ReverseMap();
            CreateMap<summary, summaryvm>().ReverseMap();
        }
       
    }
}
