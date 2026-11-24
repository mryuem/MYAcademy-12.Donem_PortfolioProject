using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("admin")]
    public class SocialController : Controller
    {
        private readonly PortfolioContext _context;

        public SocialController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult SocialIndex()
        {
            var values = _context.SocialMedia.ToList();
            return View(values);
        }

        public IActionResult CreateSocial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSocial(SocialMedia socialMedia) 
        {
            _context.SocialMedia.Add(socialMedia);
            _context.SaveChanges();
            return RedirectToAction("SocialIndex");
        }

        public IActionResult UpdateSocial(int id) 
        {
            var value=_context.SocialMedia.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateSocial(SocialMedia socialMedia)
        {
            _context.SocialMedia.Update(socialMedia);
            _context.SaveChanges();
            return RedirectToAction("SocialIndex");
        }
        public IActionResult DeleteSocial(int id) 
        {
            var value = _context.SocialMedia.Find(id);
            _context.SocialMedia.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("SocialIndex");
        }
    }
}
