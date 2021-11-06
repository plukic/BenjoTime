using ITO.Commons.BenjoTime.Core;
using ITO.Commons.BenjoTime.MVCExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ITO.Commons.BenjoTime.MVCExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDateTimeConverter _dateTimeConverter;

        public HomeController(ILogger<HomeController> logger, IDateTimeConverter dateTimeConverter)
        {
            _logger = logger;
            _dateTimeConverter = dateTimeConverter;
        }

        public IActionResult Index()
        {
            DateTime dtNow = DateTime.UtcNow;

            var client = _dateTimeConverter.FromUTCToUserDateTime(dtNow);
            var tz = _dateTimeConverter.FromUserDateTimeToUTC(client);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
