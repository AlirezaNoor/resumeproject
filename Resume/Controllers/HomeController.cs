using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RES.Query.QueryInterface;

namespace Resume.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRsumeQuery _query;
        public HomeController(ILogger<HomeController> logger, IRsumeQuery query)
        {
            _logger = logger;
            _query = query;
        }

        public IActionResult Index()
        {
            return View(_query.dtails());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Resume()
        {

            return View(_query.skilles());
        }

        public IActionResult portfolio()
        {
            return View();
        }

        public IActionResult Bolg()
        {

            return View(_query.getbloglist());
        }

        public IActionResult getBlogDetails(long id)
        {
            var x = _query.getblogdetails(id);
            return View(x);
        }
    }
}