using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly PortfolioContext _context;

        public DefaultController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.SocialMedia = _context.SocialMedia.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage (Message message)
        {
            message.SendDate = DateTime.Now;
            message.IsRead = false;
            _context.Messages.Add(message);
            _context.SaveChanges();
            TempData["MessageSent"] = "Mesajınız başarıyla gönderildi.";
            return View("~/Views/Default/Index.cshtml");
        }
    }
}
