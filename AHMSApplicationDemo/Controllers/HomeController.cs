using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AHMSApplicationDemo.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Globalization;

namespace AHMSApplicationDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult CultureManagment(String Culture)
        {
            if(Culture!=null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Culture);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Culture);
            }

            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(Culture)),
            new CookieOptions {Expires= DateTimeOffset.Now.AddDays(30) });
            return RedirectToAction(nameof(Index)); ;
        }
        public IActionResult Index()
        {
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
