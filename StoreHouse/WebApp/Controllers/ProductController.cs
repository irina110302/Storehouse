using Microsoft.AspNetCore.Mvc;
using WebApp.DataBaseSettings;
using WebApp.Models.Repositories;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service;

        public ProductController(IDBContext dbContext)
        {
            var productRepository = new ProductRepository(dbContext);

            _service = new ProductService(productRepository);
        }

        public IActionResult Index()
        {
            return View(_service.GetViewModels());
        }

        public IActionResult Create()
        {
            return View(nameof(Create));
        }

        public IActionResult Delete(int id)
        {
            _service.DeleteProduct(id);

            return View(nameof(Index), _service.GetViewModels());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductEditViewModel product)
        {
            _service.AddProduct(product);

            return View(nameof(Index), _service.GetViewModels());
        }
    }
}
