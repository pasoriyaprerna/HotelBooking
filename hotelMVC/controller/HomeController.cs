using hotelBussiness.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelMVC.controller
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IhotelBusiness _hotelBusiness;

        public HomeController(IhotelBusiness hotelBusiness)
        {
            _hotelBusiness = hotelBusiness; 
        }
      
    }
}
