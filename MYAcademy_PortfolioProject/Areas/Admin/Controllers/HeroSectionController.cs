
using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;
using MYAcademy_PortfolioProject.Models;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("admin")]
    public class HeroSectionController : Controller
    {
        private readonly PortfolioContext _context;

        public HeroSectionController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult HeroSectionIndex()
        {
            var values=_context.HeroSections.FirstOrDefault() ?? new HeroSection();

            var model = new HeroSectionViewModel
            {
                HeroSectionId = values.HeroSectionId,
                Greeting = values.Greeting,
                Title = values.Title,
                Description = values.Description,
                MainImageUrl = values.MainImageUrl
            };
           return View(model);
        }

        [HttpPost]
        public IActionResult HeroSectionIndex(HeroSectionViewModel model)
        {
            var heroSection = _context.HeroSections.FirstOrDefault();

            if (heroSection == null )
            {
                heroSection = new HeroSection();
                _context.HeroSections.Add(heroSection);
            }

            heroSection.Greeting=model.Greeting;
            heroSection.Title=model.Title;
            heroSection.Description=model.Description;

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            { 
                var extension=Path.GetExtension(model.ImageFile.FileName).ToLowerInvariant();

                var allowedExtension = new[]
                {
                    ".jpg",".jpeg",".png",".webp"
                };

                if(model.ImageFile.Length> 5*1024*1024)
                {
                    return BadRequest("Fotoğraf en fazla 5 mb olabilir.");
                }

                var fileName=Guid.NewGuid().ToString() +  extension;

                var folderPath =Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images");

                Directory.CreateDirectory(folderPath);

                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(stream);
                }
                heroSection.MainImageUrl = "/images/" + fileName;
            }

            _context.SaveChanges();

            return RedirectToAction("HeroSectionIndex");
        }
    }
}
