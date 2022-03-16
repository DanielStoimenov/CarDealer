using CarDealer.Services.Interfaces;
using CarDealer.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService _carService;

        public HomeController(ICarService carService)
        {
            this._carService = carService;
        }

        public IActionResult Index()
        {
            var cars = _carService.GetAll();
            return View(cars);
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
