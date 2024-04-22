using Microsoft.AspNetCore.Mvc;
using WebApp.DataBaseSettings;
using WebApp.Models.Repositories;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class SupplyController : Controller
    {
        private readonly SupplyService _service;

        public SupplyController(IDBContext dBContext)
        {
            var supplyRepository = new SupplyRepository(dBContext);
            var storehouseRepository = new StorehouseRepository(dBContext);
            var supplierRepository = new SupplierRepository(dBContext);

            _service = new SupplyService(
                supplyRepository,
                supplierRepository, 
                storehouseRepository);
        }

        public IActionResult Index()
        {
            return View(_service.GetViewModels());
        }

        public IActionResult Create(int supplierId, int storehouseId)
        {
            if (supplierId == 0 || storehouseId == 0)
            {
                return RedirectToAction(nameof(Index), "Supplier");
            }

            _service.CreateSupply(supplierId, storehouseId);

            return View(nameof(Index), _service.GetViewModels());
        }

        public IActionResult Delete(int supplyId)
        {
            _service.RemoveSupply(supplyId);

            return View(nameof(Index), _service.GetViewModels());
        }
    }
}
