using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public  ActionResult Index()
        {
            return View();
        }
    }
}