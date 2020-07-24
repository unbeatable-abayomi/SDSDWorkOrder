using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SDSDWorkOrder.Models;

namespace SDSDWorkOrder.Controllers
{
    [Area("WorkOrder")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserRegistration()
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }
        public IActionResult Comments()
        {
            return View();
        }
        public IActionResult Tables()
        {
            return View();
        }
        public IActionResult WorkOrder()
        {
            return View();
        }
        public IActionResult ClientTable()
        {
            return View();
        }
        public IActionResult Login()
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
