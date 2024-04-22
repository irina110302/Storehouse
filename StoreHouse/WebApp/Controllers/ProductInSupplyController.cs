using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ProductInSupplyController : Controller
    {
        public IActionResult Index(int supplyId)
        {
            return View();
        }
    }
}
