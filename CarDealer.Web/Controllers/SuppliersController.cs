using CarDealer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            this._supplierService = supplierService;
        }

        public IActionResult Search()
        {
            var suppliers = this._supplierService.GetAllSuppliers();

            return View(suppliers);
        }

        public IActionResult DoSearch(string supplier)
        {
            var parts = this._supplierService.GetAllParts(supplier);

            return View(parts);
        }
    }
}