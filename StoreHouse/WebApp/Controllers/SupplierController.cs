using Microsoft.AspNetCore.Mvc;
using WebApp.DataBaseSettings;
using WebApp.Models.Repositories;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class SupplierController : Controller
    {
        private readonly SupplierService _service;

        public SupplierController(IDBContext dbContext)
        {
            var supplierRepository = new SupplierRepository(dbContext);

            _service = new SupplierService(supplierRepository);
        }

        public ActionResult Index()
        {
            return View(_service.GetSupplierViewModels());
        }

        public ActionResult SelectSupplier(int storehouseId)
        {
            ViewBag.StorehouseId = storehouseId;

            return View("Index", _service.GetSupplierViewModels());
        }
    }
}
