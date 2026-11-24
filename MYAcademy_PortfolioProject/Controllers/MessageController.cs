using Microsoft.AspNetCore.Mvc;

namespace MYAcademy_PortfolioProject.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
