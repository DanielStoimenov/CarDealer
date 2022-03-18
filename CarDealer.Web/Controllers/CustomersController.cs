using CarDealer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        public IActionResult Index()
        {
            var customers = _customerService.GetAll();
            return View(customers);
        }
    }
}
