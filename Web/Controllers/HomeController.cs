using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [Route("weather")]
        public IActionResult Weather(string cities)
        {
            ViewBag.Cities = cities.Split(",");
            return View();
        }
    }
}