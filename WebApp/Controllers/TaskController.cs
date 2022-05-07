using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Daily()
        {
            return View();
        }

        public IActionResult Weekly()
        {
            return View();
        }

        public IActionResult Monthly()
        {
            return View();
        }
    }
}
