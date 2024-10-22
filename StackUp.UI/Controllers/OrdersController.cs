using Microsoft.AspNetCore.Mvc;

namespace StackUp.UI.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
