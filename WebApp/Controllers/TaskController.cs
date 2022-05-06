using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
