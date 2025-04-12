using Microsoft.AspNetCore.Mvc;

namespace IndividueelProject.WebApi.Controllers
{
    public class ObjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
