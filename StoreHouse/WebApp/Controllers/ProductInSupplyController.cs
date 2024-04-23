using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.DataBaseSettings;
using WebApp.Models.Entities;
using WebApp.Models.Repositories;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class ProductInSupplyController : Controller
    {
        private readonly ProductInSupplyService _service;

        public ProductInSupplyController(IDBContext dbContext)
        {
            var productInSupplyRepository = new ProductInSupplyRepository(dbContext);
            var supplyRepository = new SupplyRepository(dbContext);
            var storehouseRepository = new StorehouseRepository(dbContext);
            var supplierRepository = new SupplierRepository(dbContext);
            var productRepository = new ProductRepository(dbContext);
            var skuRepository = new SkuRepository(dbContext);

            var supplyService = new SupplyService(
                supplyRepository,
                supplierRepository,
                storehouseRepository);

            _service = new ProductInSupplyService(
                productInSupplyRepository,
                productRepository,
                skuRepository,
                supplyService);
        }

        public IActionResult Index(int supplyId)
        {
            return View(_service.GetSupplyEditViewModel(supplyId));
        }

        public IActionResult AddProductToSupply(int productId, int supplyId)
        {
            var editVm = new ProductInSupplyEditVM(productId, supplyId);

            return View("Create", editVm);
        }

        public IActionResult DeleteProductFromSupply(int productId, int supplyId) 
        {
            _service.DeleteProductFromSupply(productId);

            return View(nameof(Index), _service.GetSupplyEditViewModel(supplyId));
        }

        public IActionResult SelectProductForNewSupply(int supplyId)
        {
            return RedirectToAction("SelectProductForSupply", "Product", new { supplyId = supplyId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveProduct(ProductInSupplyEditVM model)
        {
            _service.AddProductToSupply(model);

            return View(nameof(Index), _service.GetSupplyEditViewModel(model.SupplyId));
        }
    }
}
