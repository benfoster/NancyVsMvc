using System.Web.Mvc;

namespace NancyVsMvc.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.WelcomeMessage = "Welcome to ASP.NET MVC!";
            return View();
        }
    }
}
