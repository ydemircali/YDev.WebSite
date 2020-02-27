using Microsoft.AspNetCore.Mvc;

namespace YDev.Web.Controllers
{
    public class CozumlerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
