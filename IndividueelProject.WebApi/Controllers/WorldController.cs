using Microsoft.AspNetCore.Mvc;

namespace IndividueelProject.WebApi.Controllers
{
    public class WorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
