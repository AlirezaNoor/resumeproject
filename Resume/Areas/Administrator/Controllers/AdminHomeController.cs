using Microsoft.AspNetCore.Mvc;

namespace Resume.Areas.Administrator.Controllers
{
    public class AdminHomeController : Controller
    {
        [Area("Administrator")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
