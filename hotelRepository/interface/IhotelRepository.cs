using hotelRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotelRepository.Interface
{
    public interface IhotelRepository
    {
     
        Task<List<information>> gethotel(string City);
        Task<List<information>> getallhotel();
        Task<CustInfo> postcustinfo(CustInfo cust);
        Task<List<CustInfo>> getallcust();
        Task<List<avail>> getbyavailable( DateTime check_IN, DateTime check_Out, string city);
        Task<Reservation> postreserve(Reservation reservation);
        Task<List<Hotel>> everyhotel();
        List<hotelRoom> getbyavailablehotel(DateTime check_IN, DateTime check_Out, string city);
        List<hotelRoom> getbyhotelcode(int hotelcode);
        bool postsummary(summary detail);
    }
}
