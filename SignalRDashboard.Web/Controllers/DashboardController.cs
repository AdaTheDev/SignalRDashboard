using System.Web.Mvc;

namespace SignalRDashboard.Web.Controllers
{
    public class DashboardController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Attributions()
        {
            return View();
        }
    }
}