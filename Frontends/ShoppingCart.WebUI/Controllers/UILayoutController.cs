using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
