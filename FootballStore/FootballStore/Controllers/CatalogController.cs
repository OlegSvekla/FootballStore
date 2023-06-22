using Microsoft.AspNetCore.Mvc;

namespace FootballStore.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
