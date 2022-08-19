using hotelRepository.Interface;
using hotelRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelRepository
{
    public class hotellRepository : IhotelRepository
    {
        private readonly hotell_managementContext _context;

        public hotellRepository(hotell_managementContext context)
        {
            _context = context;

        }

        public async Task<List<Hotel>> everyhotel()
        {
            var A =  await _context.Hotels.ToListAsync();
            var B =   A.GroupBy(x => x.City).Select(y => y.First()).ToList();
            return   B;
        }

        public async Task<List<CustInfo>> getallcust()
        {
            return await _context.CustInfos.ToListAsync();
        }

        public async Task<List<information>> getallhotel()
        {
            var q =  (from h in _context.Hotels
                     join ri in _context.RoomInformations on h.HotelCode equals ri.HotelCode
                    where ri.Availability == "yes"
                    select new information
                    {
                       
                        HotelName=h.HotelName,
                        Address=h.Address,
                        Postcode=h.Postcode,
                        City=h.City,
                        Country=h.Country,
                        PhoneNo=h.PhoneNo,
                        StarRating=h.StarRating,
                        ClassName=h.ClassName,
                        Image=h.Image,
                       
                        RoomId=ri.RoomId,
                        NumberOfRooms=ri.NumberOfRooms,
                        RoomType=ri.RoomType,
                        Price=ri.Price,
                       

                    });;
            return await q.ToListAsync();

        }

        public async Task<List<avail>> getbyavailable(DateTime check_IN, DateTime check_Out, string city)
        {
            var tdate = check_IN;
            var odate = check_Out;
            var date = DateTime.Now;
            var av = (from h in _context.Hotels
                      join r in _context.Reservations on h.HotelCode equals r.HotelCode
                      join ri in _context.RoomInformations on h.HotelCode equals ri.HotelCode 
                      where r.CheckOut< date && h.City == city && r.CheckOut< check_IN
                      select new avail
                      {

                          HotelName = h.HotelName,
                          Address = h.Address,
                          Postcode = h.Postcode,
                          City = h.City,
                          Country = h.Country,
                          PhoneNo = h.PhoneNo,
                          StarRating = h.StarRating,
                          ClassName = h.ClassName,
                          Image = h.Image,

                          RoomId = ri.RoomId,
                          NumberOfRooms = ri.NumberOfRooms,
                          RoomType = ri.RoomType,
                          Price = ri.Price
                      });
          
            /* foreach (var item in av)
             {
                 var change = _context.RoomInformations.Where(x => x.RoomId == item.RoomId).SingleOrDefault();
                 change.Availability = "yes";
                 _context.SaveChanges();

             }*/
            /* var av1 = (from h in _context.Hotels
                       join r in _context.Reservations on h.HotelCode equals r.HotelCode
                       join ri in _context.RoomInformations on h.HotelCode equals ri.HotelCode
                       where r.CheckOut > date
                       select new avail
                       {

                           HotelName = h.HotelName,
                           Address = h.Address,
                           Postcode = h.Postcode,
                           City = h.City,
                           Country = h.Country,
                           PhoneNo = h.PhoneNo,
                           StarRating = h.StarRating,
                           ClassName = h.ClassName,
                           Image = h.Image,

                           RoomId = ri.RoomId,
                           NumberOfRooms = ri.NumberOfRooms,
                           RoomType = ri.RoomType,
                           Price = ri.Price
                       });
             foreach (var item in av)
             {
                 var change = _context.RoomInformations.Where(x => x.RoomId == item.RoomId).SingleOrDefault();
                 change.Availability = "no";
                 _context.SaveChanges();

             }*/

            return await av.ToListAsync();
        }

        public async Task<List<information>> gethotel(string City)
        {

            var q = (from h in _context.Hotels
                     join ri in _context.RoomInformations on h.HotelCode equals ri.HotelCode
                     where ri.Availability == "yes" && h.City==City 
                     select new information
                     {

                         HotelName = h.HotelName,
                         Address = h.Address,
                         Postcode = h.Postcode,
                         City = h.City,
                         Country = h.Country,
                         PhoneNo = h.PhoneNo,
                         StarRating = h.StarRating,
                         ClassName = h.ClassName,
                         Image = h.Image,

                         RoomId = ri.RoomId,
                         NumberOfRooms = ri.NumberOfRooms,
                         RoomType = ri.RoomType,
                         Price = ri.Price,


                     }); ;
            
            return await q.ToListAsync();

        }

        public async Task<CustInfo> postcustinfo(CustInfo cust)
        {
            var result = await _context.CustInfos.AddAsync(cust);
           await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Reservation> postreserve(Reservation reservation)
        {
            var result = await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public List<hotelRoom> getbyavailablehotel(DateTime check_IN, DateTime check_Out, string city)
        {
            var tdate = check_IN;
            var odate = check_Out;
            var todate = DateTime.Now;
            // var date = DateTime.Now;
            /*  var available = _context.Reservations.Where(x =>  x.CheckIn < check_Out ).ToList();
              available = available.Where(x => x.CheckOut > check_Out).ToList();

              var allRooms = _context.RoomInformations.ToList();
              List<RoomInformation> A = new List<RoomInformation>();
              foreach (var item in available)
              {
                 A =  allRooms.Where(x => x.RoomId == item.RoomId ).ToList();

              }*/
            var unavailable = (from r in _context.Reservations
                               join res in _context.RoomInformations on r.RoomId equals res.RoomId
                               join h in _context.Hotels on res.HotelCode equals h.HotelCode

                               where r.RoomId == res.RoomId &&
                               (r.CheckIn <= check_IN && check_IN <= r.CheckOut)
                              || (r.CheckIn <= check_Out && check_Out <= r.CheckOut)
                               select new hotelRoom
                               {
                                   RoomId = res.RoomId,
                                   HotelName = h.HotelName,
                                   Availability = res.Availability

                               }

                              ).ToList();

            foreach (var item in unavailable)
            {
                RoomInformation obj1 = _context.RoomInformations.Where(x => x.RoomId == item.RoomId).SingleOrDefault();
                obj1.Availability = "no";
                _context.SaveChanges();
            }

            var avail = (from r in _context.Reservations
                               join res in _context.RoomInformations on r.RoomId equals res.RoomId
                               join h in _context.Hotels on res.HotelCode equals h.HotelCode

                               where r.RoomId == res.RoomId &&
                               (r.CheckOut< todate || r.CheckIn > todate)
                               select new hotelRoom
                               {
                                   RoomId = res.RoomId,
                                   HotelName = h.HotelName,
                                   Availability = res.Availability

                               }

                              ).ToList();
            foreach (var item in avail)
            {
                RoomInformation obj1 = _context.RoomInformations.Where(x => x.RoomId == item.RoomId).SingleOrDefault();
                obj1.Availability = "yes";
                _context.SaveChanges();
            }



            var result = new List<RoomInformation>();
            RoomInformation obj = new RoomInformation();
            var roomlist = _context.RoomInformations.ToList();

            for (int i = 0; i < unavailable.Count; i++)
            {
                obj = _context.RoomInformations.Where(x => x.RoomId == unavailable[i].RoomId).First();
                roomlist.Remove(obj);

            }



            var available = (from r in _context.RoomInformations

                             join h in _context.Hotels on r.HotelCode equals h.HotelCode

                             where r.RoomId == r.RoomId && r.Availability == "yes" && h.City == city

                             select new hotelRoom
                             {
                                 HotelName = h.HotelName,
                                 HotelCode = h.HotelCode,
                                 Image = h.Image,
                                 ClassName = h.ClassName,
                                 StarRating = h.StarRating,
                                 Price=r.Price,
                                 RoomType=r.RoomType

                             }

                            ).ToList();

            return available.GroupBy(x => x.HotelName).Select(y => y.First()).ToList();
        }

        public List<hotelRoom> getbyhotelcode(int hotelcode)
        {
            //var todate = DateTime.Now;
            //var avail = (from r in _context.Reservations
            //             join res in _context.RoomInformations on r.RoomId equals res.RoomId
            //             join h in _context.Hotels on res.HotelCode equals h.HotelCode

            //             where r.RoomId == res.RoomId &&
            //             (r.CheckOut < todate || r.CheckIn> todate) 
            //             select new hotelRoom
            //             {
            //                 RoomId = res.RoomId,
            //                 HotelName = h.HotelName,
            //                 Availability = res.Availability

            //             }

            //                ).ToList();
            //foreach (var item in avail)
            //{
            //    RoomInformation obj1 = _context.RoomInformations.Where(x => x.RoomId == item.RoomId).SingleOrDefault();
            //    obj1.Availability = "yes";
            //    _context.SaveChanges();
           // }
            var q = (from h in _context.Hotels
                     join ri in _context.RoomInformations on h.HotelCode equals ri.HotelCode
                     where h.HotelCode==hotelcode && ri.Availability=="yes"
                     select new hotelRoom
                     { 

                         HotelCode = h.HotelCode,
                         HotelName = h.HotelName,
                         Address = h.Address,
                         Postcode = h.Postcode,
                         City = h.City,
                         Country = h.Country,
                         PhoneNo = h.PhoneNo,
                         StarRating = h.StarRating,
                         ClassName = h.ClassName,
                         Image = h.Image,

                         RoomId = ri.RoomId,
                         NumberOfRooms = ri.NumberOfRooms,
                         RoomType = ri.RoomType,
                         Price = ri.Price,

                     }).ToList(); 

            return  q.GroupBy(x => x.HotelName).Select(y => y.First()).ToList();
        }
        public bool postsummary(summary detail)
        {   

            var a = detail.Amount;
            var b = detail.CheckIn;
            var c = detail.CheckOut;
            var d = detail.Custfname;
            var e = detail.Custlname;

         
            var i = detail.EmailAddress;
            var j = detail.HotelCode;
          
            
            var m = detail.RoomId;

            CustInfo custom = new CustInfo();
            custom.Custfname = d;
            custom.Custlname = e;
            custom.EmailAddress = i;
            _context.CustInfos.Add(custom);
            _context.SaveChanges();

            var custid = _context.CustInfos.Where(x => x.EmailAddress == custom.EmailAddress).FirstOrDefault();

            Reservation reserved = new Reservation();
            reserved.Amount = a;
            reserved.CheckIn = b;
            reserved.CheckOut = c;
            reserved.CustomerId = custid.CustomerId;
          
           
            reserved.HotelCode = j;
            
           
            reserved.RoomId = m;

            _context.Reservations.Add(reserved);
            _context.SaveChanges();
            return true;
        }
    }
}
