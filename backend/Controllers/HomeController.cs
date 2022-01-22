using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppShiba.Models;
using WebAppShiba.Service;
namespace WebAppShiba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [EnableCors("AllowOrigin")]
        public IActionResult Index(int numeroShiba)
        {
            if(numeroShiba>0)
            {
                ViewBag.Shiba=DataFetcherShiba.CallApi(numeroShiba);
            }
            return Ok(DataFetcherShiba.CallApi(numeroShiba));
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
