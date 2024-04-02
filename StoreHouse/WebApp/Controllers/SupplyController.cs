using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SupplyController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int supplierId, int storehouseId)
        {


            return View("Edit", );
        }

        public IActionResult Edit(int supplyId)
        {


            return View();
        }
    }
}
