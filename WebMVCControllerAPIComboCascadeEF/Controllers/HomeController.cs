using Microsoft.AspNetCore.Mvc;

namespace WebMVCControllerAPIComboCascadeEF.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
