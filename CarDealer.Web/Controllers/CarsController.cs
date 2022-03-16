using CarDealer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            this._carService = carService;
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult DoSearch(string make)
        {
            var cars = this._carService.SearchByMake(make);
            return View(cars);
        }
    }
}