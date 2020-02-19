using Microsoft.AspNetCore.Mvc;

namespace rocketshoes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Logged = HelperControllers.VerifyLoggedUser(HttpContext.Session);

            if (ViewBag.Logged)
                return View("IndexLogged");

            return View();
        }


        public IActionResult About()
        {
            ViewBag.Logged = HelperControllers.VerifyLoggedUser(HttpContext.Session);

            if (ViewBag.Logged)
                return View("About");

            return View("About");
        }
    }
}
