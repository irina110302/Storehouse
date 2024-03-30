using Microsoft.AspNetCore.Mvc;
using WebApp.DataBaseSettings;
using WebApp.Models.Repositories;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class StorehouseController : Controller
    {
        private readonly StorehouseService _service;

        public StorehouseController(IDBContext dbContext)
        {
            var storehouseRepository = new StorehouseRepository(dbContext);

            _service = new StorehouseService(storehouseRepository);
        }

        public ActionResult Index()
        {
            return View(_service.GetViewModelsList());
        }
    }
}
