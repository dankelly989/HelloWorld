using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Home page.";

            return View("Index");
        }

        /*public async Task<ActionResult> Index(string returnUrl)
        {
            return RedirectToAction("Solitaire", "Games");
        }*/
    }
}
