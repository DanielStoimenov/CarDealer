using CarDealer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    public class PartsController : Controller
    {
        private readonly IPartService _partService;

        public PartsController(IPartService partService)
        {
            this._partService = partService;
        }

        public IActionResult ListAllParts()
        {
            var parts = this._partService.GetAll();
            return View(parts);
        }
    }
}
